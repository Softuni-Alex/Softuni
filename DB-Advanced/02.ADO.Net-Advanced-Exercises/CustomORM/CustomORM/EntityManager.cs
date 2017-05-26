using CustomORM.Attributes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CustomORM
{
    /// <summary>
    /// Insert, update and retrieve entity objects
    /// </summary>
    public class EntityManager
    {
        private SqlConnection connection;
        private string connectionString;
        private bool isCodeFirst;

        public EntityManager(string connectionString, bool isCodeFirst)
        {
            this.connectionString = connectionString;
            this.isCodeFirst = isCodeFirst;
        }

        public T FindById<T>(int id)
        {
            T wantedObject = default(T);
            string query = $"SELECT * FROM {this.GetTableName(typeof(T))} WHERE Id = {id}";
            using (connection = new SqlConnection(this.connectionString))
            {
                this.connection.Open();
                SqlCommand command = new SqlCommand(query, this.connection);
                SqlDataReader reader = command.ExecuteReader();
                wantedObject = CreateEntity<T>(reader);
            }

            return wantedObject;
        }

        public IEnumerable<T> FindAll<T>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll<T>(string @where)
        {
            throw new NotImplementedException();
        }

        public T FindFirst<T>()
        {
            throw new NotImplementedException();
        }

        public T FindFirst<T>(string @where)
        {
            throw new NotImplementedException();
        }

        public bool Persist(object entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Cannot persist null entity");
            }

            if (isCodeFirst && !CheckIfTableExists(entity.GetType()))
            {
                this.CreateTable(entity.GetType());
            }

            Type entityType = entity.GetType();
            FieldInfo idInfo = GetId(entityType);
            int id = (int)idInfo.GetValue(entity);

            if (id <= 0)
            {
                return this.Insert(entity, idInfo);
            }

            return this.Update(entity, idInfo);
        }

        private void CreateTable(Type entity)
        {
            string creationString = PrepareTableCreationString(entity);
            using (connection = new SqlConnection(this.connectionString))
            {
                this.connection.Open();
                SqlCommand command = new SqlCommand(creationString, this.connection);
                command.ExecuteNonQuery();
            }
        }

        private string PrepareTableCreationString(Type entity)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"CREATE TABLE {GetTableName(entity)} (");
            builder.Append($"Id INT PRIMARY KEY IDENTITY(1,1), ");

            FieldInfo[] columnsInfos =
                entity.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(x => x.IsDefined(typeof(ColumnAttribute)))
                .ToArray();


            foreach (FieldInfo columnField in columnsInfos)
            {
                builder.Append($"{this.GetFieldName(columnField)} {this.GetFieldName(columnField)}, ");
            }
            builder.Remove(builder.Length - 2, 2);
            builder.Append(")");

            return builder.ToString();
        }

        private bool Update(object entityType, FieldInfo idInfo)
        {
            int numberOfAffectedRows = 0;

            string updateString = this.PrepareEntityUpdateString(entityType, idInfo);
            using (this.connection = new SqlConnection(this.connectionString))
            {
                this.connection.Open();
                SqlCommand updateCommand = new SqlCommand(updateString, this.connection);
                numberOfAffectedRows = updateCommand.ExecuteNonQuery();
            }

            return numberOfAffectedRows > 0;
        }

        private string PrepareEntityUpdateString(object entity, FieldInfo idInfo)
        {
            StringBuilder updateString = new StringBuilder();
            updateString.Append($"UPDATE {GetTableName(entity.GetType())} SET ");

            StringBuilder settings = new StringBuilder();

            FieldInfo[] columnFields = entity.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(x => x.IsDefined(typeof(ColumnAttribute))).ToArray();

            foreach (FieldInfo columnField in columnFields)
            {
                settings.Append($"{this.GetFieldName(columnField)} = '{columnField.GetValue(entity)}', ");
            }

            settings.Remove(settings.Length - 2, 2);
            updateString.Append(settings);

            updateString.Append($" WHERE Id = {idInfo.GetValue(entity)}");

            return updateString.ToString();
        }

        private bool Insert(object entityType, FieldInfo idInfo)
        {
            int numberOfAffectedRows = 0;

            string insertionString = PrepareEntityInsertionString(entityType);
            using (connection = new SqlConnection(this.connectionString))
            {
                this.connection.Open();
                SqlCommand insertionCommand = new SqlCommand(insertionString, this.connection);
                numberOfAffectedRows = insertionCommand.ExecuteNonQuery();

                string query = $"SELECT MAX(Id) FROM {GetTableName(entityType.GetType())}";
                SqlCommand getLastIdCommand = new SqlCommand(query, this.connection);
                int id = (int)getLastIdCommand.ExecuteScalar();
                idInfo.SetValue(entityType, id);
            }

            return numberOfAffectedRows > 0;
        }

        private string PrepareEntityInsertionString(object entity)
        {
            StringBuilder insertionString = new StringBuilder();
            StringBuilder columnNamesString = new StringBuilder();
            StringBuilder valueString = new StringBuilder();

            insertionString.Append($"INSERT INTO {this.GetTableName(entity.GetType())}(");

            FieldInfo[] columnFields = entity.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(x => x.IsDefined(typeof(ColumnAttribute))).ToArray();

            foreach (FieldInfo columnField in columnFields)
            {
                string value = columnField.GetValue(entity).ToString();
                columnNamesString.Append($"{this.GetFieldName(columnField)}, ");
                valueString.Append($"'{value}', ");
            }
            columnNamesString = columnNamesString.Remove(columnNamesString.Length - 2, 2);
            valueString = valueString.Remove(valueString.Length - 2, 2);

            insertionString.Append(columnNamesString);
            insertionString.Append(") VALUES(");
            insertionString.Append(valueString);
            insertionString.Append(")");

            return insertionString.ToString();
        }

        private bool CheckIfTableExists(Type type)
        {
            string query =
                $"SELECT COUNT(name) " +
                $"FROM sys.sysobjects " +
                $"WHERE [Name] = '{this.GetTableName(type)}' AND [xtype] = 'U'";

            int numberOfTables = 0;
            using (connection = new SqlConnection(this.connectionString))
            {
                this.connection.Open();
                SqlCommand command = new SqlCommand(query, this.connection);
                numberOfTables = (int)command.ExecuteScalar();
            }

            return numberOfTables > 0;
        }

        private T CreateEntity<T>(SqlDataReader reader)
        {
            reader.Read();
            object[] columns = new object[reader.FieldCount];
            reader.GetValues(columns);

            Type[] types = new Type[columns.Length - 1];
            object[] fieldValues = new object[columns.Length - 1];


            for (int i = 1; i < columns.Length; i++)
            {
                types[i - 1] = columns[i].GetType();
                fieldValues[i - 1] = columns[i];
            }

            T createdObject = (T)typeof(T).GetConstructor(types).Invoke(fieldValues);
            FieldInfo idInfo = createdObject.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.IsDefined(typeof(IdAttribute)));


            idInfo.SetValue(createdObject, columns[0]);

            return createdObject;
        }

        private FieldInfo GetId(Type entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Cannot get id for null type!");
            }

            var field = entity.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(x => x.IsDefined(typeof(IdAttribute)));

            if (field == null)
            {
                throw new InvalidOperationException("Cannot operate with entity without primary key");
            }
            return field;
        }

        private string GetTableName(Type entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Table null!");
            }

            if (!entity.IsDefined(typeof(EntityAttribute)))
            {
                throw new ArgumentException("Cannot get table name of entity!");
            }

            string tableName = entity.GetCustomAttribute<EntityAttribute>().TableName;

            if (tableName == null)
            {
                throw new ArgumentNullException("Table name cannot be null!");
            }

            return tableName;
        }

        private string GetFieldName(FieldInfo field)
        {
            if (field == null)
            {
                throw new ArgumentNullException("Field cannot be null");
            }

            if (!field.IsDefined(typeof(ColumnAttribute)))
            {
                return field.Name;
            }

            string columnName = field.GetCustomAttribute<ColumnAttribute>().Name;
            if (columnName == null)
            {
                throw new ArgumentNullException("Column name cannot be null!");
            }

            return columnName;

        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTownNamesCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = @"Server=(localdb)\MSSQLLocalDB;Database=MinionsDB;Trusted_Connection=True;";
            SqlConnection connect = new SqlConnection(connection);

            string nameCountry = Console.ReadLine();

            using (connect)
            {
                connect.Open();

                int CountryId = GetCountryIdByName(nameCountry, connect);
                ChangeTownsNameToUpperCase(CountryId, connect);
                int townsCount = FindNumberTowns(CountryId, connect);
                PrintAffectedRows(CountryId, townsCount, connect);

                Console.WriteLine();
            }
        }

        private static int FindNumberTowns(int CountryId, SqlConnection connect)
        {
            string sqlCommand2 = string.Format("SELECT COUNT(t.Name) FROM dbo.Towns AS t WHERE t.CountryID = {0}", CountryId);
            SqlCommand command2 = new SqlCommand(sqlCommand2, connect);
            int towns = (int)command2.ExecuteScalar();
            return towns;
        }

        private static void PrintAffectedRows(int CountryId,int towns, SqlConnection connect)
        {
            string sqlCommand = string.Format("SELECT t.Name FROM dbo.Towns AS t WHERE t.CountryID = {0}", CountryId);
            SqlCommand command = new SqlCommand(sqlCommand, connect);
            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                Console.WriteLine("{0} town names were affected.", towns);
                Console.Write("[");
                while (reader.Read())
                {
                    
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader[i] + ", ");
                    }
                    
                }
                Console.Write("]");
            }
        }

        private static void ChangeTownsNameToUpperCase(int CountryId, SqlConnection connect)
        {
            string sqlCommand = string.Format("UPDATE Towns SET Name = UPPER(Name) WHERE CountryID = {0}", CountryId);
            SqlCommand command = new SqlCommand(sqlCommand, connect);
            command.ExecuteNonQuery();
        }

        private static int GetCountryIdByName(string nameCountry, SqlConnection connect)
        {
            int countryId = 0;
            string sqlCommand = string.Format("SELECT c.CountryID FROM dbo.Country AS c WHERE c.CountryName = '{0}'", nameCountry);
            SqlCommand command = new SqlCommand(sqlCommand, connect);
            countryId = (int)command.ExecuteScalar();
            return countryId;
        }
    }
}

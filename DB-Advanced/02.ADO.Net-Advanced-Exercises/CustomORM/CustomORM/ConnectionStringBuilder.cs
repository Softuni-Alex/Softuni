namespace CustomORM
{
    using System.Data.SqlClient;

    /// <summary>
    /// Generates connection strings by given db name
    /// </summary>
    public class ConnectionStringBuilder
    {
        private readonly SqlConnectionStringBuilder builder;

        public ConnectionStringBuilder(string databaseName)
        {
            this.builder = new SqlConnectionStringBuilder
            {
                ["Data Source"] = "(local)",
                ["Integrated Security"] = true,
                ["Connection Timeout"] = 1000,
                ["Trusted_Connection"] = true,
                ["Initial Catalog"] = databaseName
            };
            this.ConnectionString = this.builder.ToString();
        }

        public string ConnectionString { get; }
    }
}
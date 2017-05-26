using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintAllMinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = @"Server=(localdb)\MSSQLLocalDB;Database=MinionsDB;Trusted_Connection=True;";
            SqlConnection connect = new SqlConnection(connection);

            using (connect)
            {
                connect.Open();
                int count = ChangeTownsNameToUpperCase(connect);
                Console.WriteLine(count);
                PrintMinionsNamesInSpecifyOrder(count,connect);
            }
        }

        private static int ChangeTownsNameToUpperCase(SqlConnection connect)
        {
            string sqlCommand = string.Format("SELECT COUNT(m.Name) FROM dbo.Minions AS m");
            SqlCommand command = new SqlCommand(sqlCommand, connect);
            return (int)command.ExecuteScalar();
        }
        private static void PrintMinionsNamesInSpecifyOrder(int count,SqlConnection connect)
        {
            string sqlCommand = "SELECT m.Name FROM dbo.Minions AS m";
            SqlCommand command = new SqlCommand(sqlCommand, connect);
            SqlDataReader reader = command.ExecuteReader();
            var listNames = new List<string>();

            using (reader)
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        listNames.Add((string)reader[i]);
                    }
                }
            }
            int count2 = 0;
            for (int i = 0; i < listNames.Count; i++)
            {
                if (count2 % 2 == 0)
                {
                    Console.WriteLine(listNames[i]);
                    count2++;
                }
                else
                {
                    Console.WriteLine(listNames[count - i]);
                    count2++;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncreaseMinionsAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = @"Server=(localdb)\MSSQLLocalDB;Database=MinionsDB;Trusted_Connection=True;";
            SqlConnection connect = new SqlConnection(connection);

            var ID = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            using (connect)
            {
                connect.Open();
                foreach (var Id in ID)
                {
                    IncrementAgeMInionsById(Id, connect);
                }
                PrintAllMinions(connect);
            }
        }

        private static void PrintAllMinions(SqlConnection connect)
        {
            string sqlCommand = "SELECT m.Name, m.Age FROM dbo.Minions AS m";
            SqlCommand command = new SqlCommand(sqlCommand, connect);
            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader[i] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        private static void IncrementAgeMInionsById(int Id, SqlConnection connect)
        {
            string sqlCommand = string.Format("UPDATE Minions SET Age += 1 WHERE MinionsID = {0}", Id);
            SqlCommand command = new SqlCommand(sqlCommand, connect);
            command.ExecuteNonQuery();
        }
    }
}

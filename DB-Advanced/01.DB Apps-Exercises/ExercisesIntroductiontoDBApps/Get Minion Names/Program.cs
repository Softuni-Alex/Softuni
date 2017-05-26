using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_Minion_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            string connection = @"Server=(localdb)\MSSQLLocalDB;Database=MinionsDB;Trusted_Connection=True;";
            SqlConnection connect = new SqlConnection(connection);
            connect.Open();

            using (connect)
            {
                SqlCommand command = new SqlCommand(string.Format(@"SELECT v.Name,m.Name,m.Age FROM dbo.Villains AS v
                                                    INNER JOIN dbo.MinionsVillains AS mv
                                                    	ON mv.VillainsID = v.VillainsID
                                                    INNER JOIN dbo.Minions AS m
                                                    	ON m.MinionsID = mv.MinionsID
                                                    	WHERE V.VillainsID = {0}",id),connect);
                string name = (string)command.ExecuteScalar();
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    Console.WriteLine(name);
                    while (reader.Read())
                    {
                        for (int i = 1; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader[i] + " ");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}

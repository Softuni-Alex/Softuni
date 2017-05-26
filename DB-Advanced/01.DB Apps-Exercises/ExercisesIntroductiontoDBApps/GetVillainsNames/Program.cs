using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetVillainsNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = @"Server=(localdb)\MSSQLLocalDB;Database=MinionsDB;Trusted_Connection=True;";
            SqlConnection connect = new SqlConnection(connection);
            connect.Open();
            using (connect)
            {
                SqlCommand command = new SqlCommand(@"SELECT distinct V.Name,COUNT(mv.MinionsID) FROM dbo.Villains AS v
                                                    INNER JOIN DBO.MinionsVillains AS mv
                                                    	ON mv.VillainsID = v.VillainsID
                                                    GROUP BY V.Name, mv.VillainsID", connect);
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
        }
    }
}

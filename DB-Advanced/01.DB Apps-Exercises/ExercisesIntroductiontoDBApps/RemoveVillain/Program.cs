using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveVillain
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = @"Server=(localdb)\MSSQLLocalDB;Database=MinionsDB;Trusted_Connection=True;";
            SqlConnection connect = new SqlConnection(connection);

            int iD = int.Parse(Console.ReadLine());

            using (connect)
            {
                connect.Open();
                int relaseMinions = RemoveMinionsByIdVillian(iD, connect);
                string nameVillianRemove = RemoveVillainsById(iD, connect);
                Console.WriteLine("{0} was deleted",nameVillianRemove);
                Console.WriteLine("{0} minions released",relaseMinions);

            }
        }

        private static string RemoveVillainsById(int iD, SqlConnection connect)
        {
            string nameVillain;
            SqlCommand command = new SqlCommand("dbo.usp_RemoveVillains", connect);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@VillainID", iD);
            nameVillain = (string)command.ExecuteScalar();
            return nameVillain;
        }

        private static int RemoveMinionsByIdVillian(int iD, SqlConnection connect)
        {
            int relaseMinions = 0;
            SqlCommand command = new SqlCommand("dbo.usp_GetRemoveMinionsOfVilliansRealease", connect);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@VillainID", iD);
            relaseMinions = (int)command.ExecuteScalar();
            return relaseMinions;
        }
    }
}

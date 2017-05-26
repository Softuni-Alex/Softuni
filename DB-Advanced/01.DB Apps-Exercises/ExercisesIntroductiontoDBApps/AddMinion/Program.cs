using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddMinion
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = AddMinion.Properties.Settings.Default.myConnection;
            //string connection = @"Server=(localdb)\MSSQLLocalDB;Database=MinionsDB;Trusted_Connection=True;";
            SqlConnection connect = new SqlConnection(connection);

            var inputMinion = Console.ReadLine().Split().ToArray();
            var inputVIllians = Console.ReadLine().Split().ToArray();

            string nameMinion = inputMinion[1];
            int minionAge = int.Parse(inputMinion[2]);
            string townName = inputMinion[3];

            string villianName = inputVIllians[1];

            using (connect)
            {
                connect.Open();
                bool IsExist =  IsExistVillians(villianName,connect);
                bool IsExistMinion = IsExistMinions(nameMinion, connect);
                bool IsExistTowns = IsExistTown(townName, connect);

                if (!IsExistTowns)
                {
                    AddTown(townName, connect);
                    Console.WriteLine("Town {0} was added to the database.", townName);
                }
                if (!IsExist)
                {
                    AddVillains(villianName,connect);
                    Console.WriteLine("Villain {0} was added to the database.",villianName);
                }

                int townID = GetTownIdByName(townName, connect);
                AddMinions(nameMinion,minionAge,townID, connect);

                int minionId = GetMinionIdByName(nameMinion, connect);
                int villianId = GetVillainIdByName(villianName, connect);

                AddMinionToVillans(minionId, villianId,connect);
                Console.WriteLine("Successfully added {0} to be minion of {1}",nameMinion,villianName);
            }
        }

        private static int GetTownIdByName(string townName, SqlConnection connect)
        {
            int townId = 0;
            string sqlCommand = "SELECT t.TownID FROM dbo.Towns AS t WHERE t.Name = @townName";
            SqlCommand command = new SqlCommand(sqlCommand, connect);
            command.Parameters.AddWithValue("@townName",townName);
            townId = (int)command.ExecuteScalar();
            return townId;
        }

        private static void AddMinionToVillans(int minionId, int villianId,SqlConnection connect)
        {
            string sqlCommand = string.Format("INSERT INTO MinionsVillains (MinionsID,VillainsID) VALUES({0},{1})",minionId,villianId);
            SqlCommand command = new SqlCommand(sqlCommand, connect);
            command.ExecuteNonQuery();
        }

        private static int GetVillainIdByName(string villianName, SqlConnection connect)
        {
            int villainId = 0;
            string sqlCommand = "SELECT v.VillainsID FROM dbo.Villains AS v WHERE v.Name = @villansName";
            SqlCommand command = new SqlCommand(sqlCommand, connect);
            command.Parameters.AddWithValue("@villansName", villianName);
            villainId = (int)command.ExecuteScalar();
            return villainId;
        }

        private static int GetMinionIdByName(string nameMinion, SqlConnection connect)
        {
            int minionId = 0;
            string sqlCommand = "SELECT m.MinionsID FROM dbo.Minions AS m WHERE m.Name = @MinionsName";
            SqlCommand command = new SqlCommand(sqlCommand, connect);
            command.Parameters.AddWithValue("@MinionsName", nameMinion);
            minionId = (int)command.ExecuteScalar();
            return minionId;
        }

        private static void AddVillains(string villianName,SqlConnection connect)
        {
           SqlCommand command = new SqlCommand(string.Format(@"INSERT INTO Villains(Name,EvilnesFactor)
                                                                    VALUES('{0}','good')",villianName), connect);
            command.ExecuteNonQuery();
            
        }

        private static void AddMinions(string minionName, int minionAge,int townID, SqlConnection connect)
        {
           SqlCommand command = new SqlCommand(string.Format(@"INSERT INTO Minions(Name,Age,TownID)
                                                                VALUES('{0}',{1},{2})",minionName,minionAge,townID), connect);
            command.ExecuteNonQuery();
     
        }

        private static void AddTown(string townName,SqlConnection connect)
        {
            SqlCommand command = new SqlCommand(string.Format(@"INSERT INTO Towns(Name) VALUES('{0}')",
                                                townName), connect);
            command.ExecuteNonQuery();
            
        }

        private static bool IsExistTown(string p, SqlConnection connect)
        {
            SqlCommand command3 = new SqlCommand(string.Format(@"SELECT c.CountryName FROM dbo.Country AS c
                                                                 WHERE c.CountryName = '{0}'", p), connect);
            string name = (string)command3.ExecuteScalar();

            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static bool IsExistMinions(string p, SqlConnection connect)
        {
            SqlCommand command2 = new SqlCommand(string.Format(@"SELECT m.Name FROM dbo.Minions AS m
                                                                 WHERE m.Name = '{0}'", p), connect);
            string name = (string)command2.ExecuteScalar();

            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            else
            {
                return true;
            }   
        }

        private static bool IsExistVillians(string p, SqlConnection connect)
        {
            SqlCommand command = new SqlCommand(string.Format(@"SELECT v.Name FROM dbo.Villains AS v
                                                                 WHERE v.Name = '{0}'", p), connect);
            string name = (string)command.ExecuteScalar();

            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        
    }
}

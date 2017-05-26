using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace InitialSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = @"Server=(localdb)\MSSQLLocalDB;Database=MinionsDB;Trusted_Connection=True;";
            SqlConnection connect = new SqlConnection(connection);
            connect.Open();
            using(connect)
            {
                SqlCommand command = new SqlCommand(@"CREATE TABLE Country(
                                                    CountryID INT PRIMARY KEY IDENTITY(1,1),
                                                    CountryName VARCHAR(50)
                                                    )
                                                    CREATE TABLE Towns(
                                                    TownID INT PRIMARY KEY IDENTITY(1,1),
                                                    Name VARCHAR(50),
                                                    CountryID INT,
                                                    CONSTRAINT FK_Towns_Country FOREIGN KEY(CountryID)
                                                    REFERENCES Country(CountryID)
                                                    )
                                                    CREATE TABLE Minions(
                                                    MinionsID INT PRIMARY KEY IDENTITY(1,1),
                                                    Name VARCHAR(50),
                                                    Age INT,
                                                    TownID INT,
                                                    CONSTRAINT FK_Minions_Towns FOREIGN KEY(TownID)
                                                    REFERENCES Towns(TownID)
                                                    )
                                                    
                                                    CREATE TABLE Villains(
                                                    VillainsID INT PRIMARY KEY IDENTITY(1,1),
                                                    Name VARCHAR(50),
                                                    EvilnesFactor VARCHAR(10),
                                                    CONSTRAINT CH_EvilnesFactor CHECK(EvilnesFactor IN ('good', 'bad', 'evil', 'super evil'))
                                                    )
                                                    
                                                    CREATE TABLE MinionsVillains(
                                                    VillainsID INT,
                                                    MinionsID INT,
                                                    CONSTRAINT PF_VillainsID_MinionsID PRIMARY KEY(VillainsID,MinionsID),
                                                    CONSTRAINT FK_MinionsVillains_Villains FOREIGN KEY(VillainsID)
                                                    REFERENCES Villains(VillainsID),
                                                    CONSTRAINT FK_MinionsVillains_Minions FOREIGN KEY(MinionsID)
                                                    REFERENCES Minions(MinionsID)
                                                    )", connect);
                command.ExecuteNonQuery();
          
                SqlCommand command2 = new SqlCommand(@"INSERT INTO Country(CountryName)
                                                    VALUES('Bulgaria'),
                                                    ('Spain'),
                                                    ('France'),
                                                    ('Germany'),
                                                    ('Serbia')

                                                    INSERT INTO Towns(Name,CountryID)
                                                    VALUES('Sofia',1),
                                                    ('Madrid',2),
                                                    ('Paris',3),
                                                    ('Munich',4),
                                                    ('Belgrade',5)
                                                    
                                                    INSERT INTO Minions(Name,Age,TownID)
                                                    VALUES
                                                    ('Krasi',23,1),
                                                    ('Alex',20,5),
                                                    ('Kiril',21,3),
                                                    ('Pesho',10,2),
                                                    ('Kolio',23,4)
                                                    
                                                    INSERT INTO Villains (Name,EvilnesFactor)
                                                    VALUES
                                                    ('Nedko','good'),
                                                    ('Svetlio','bad'),
                                                    ('Mishka','evil'),
                                                    ('Selanin','super evil'),
                                                    ('Nekadarnik','bad')
                                                    
                                                    INSERT INTO MinionsVillains(VillainsID,MinionsID)
                                                    VALUES
                                                    (1,2),
                                                    (1,3),
                                                    (1,4),
                                                    (4,2),
                                                    (4,5)", connect);
                command2.ExecuteNonQuery();
            }

        }
    }
}

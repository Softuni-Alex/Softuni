namespace CustomORM.Entities
{
    using Attributes;
    using System;

    /// <summary>
    /// Creating a class that will 
    /// represent our table in database
    /// using the following properties for columns
    /// </summary>
    [Entity(TableName = "Users")]
    public class User
    {
        [Id]
        private int id;

        [Column(Name = "Username")]
        private string username;

        [Column(Name = "Password")]
        private string password;

        [Column(Name = "Age")]
        private int age;

        [Column(Name = "RegistrationDate")]
        private DateTime registrationDate;

        public User(string username, string password, int age, DateTime registrationDate)
        {
            this.Username = username;
            this.Password = password;
            this.Age = age;
            this.RegistrationDate = registrationDate;
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
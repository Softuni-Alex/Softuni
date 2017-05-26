namespace MiniORMLive
{
    using System;
    using CustomORM.Core;
    using MiniORMLive.Entities;

    class Program
    {
        static void Main()
        {
            string connectionString = new ConnectionStringBuilder("MyWebSiteDatabase").ConnectionString;
            IDbContext context = new EntityManager(connectionString, true);

            User nasko = context.FindById<User>(7);
            Console.WriteLine($"{nasko.Username} - {nasko.Age}");
        }
    }
}

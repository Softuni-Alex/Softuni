namespace BookShopSystem.ConsoleClient
{
    using Data;
    using Data.Migrations;
    using System.Data.Entity;
    using System.Linq;

    public class ClientApp
    {
        public static void Main()
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>();
            Database.SetInitializer(migrationStrategy);

            var context = new BookShopContext();
            var bookCount = context.Books.Count();
        }
    }
}
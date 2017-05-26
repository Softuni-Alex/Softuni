using System.Data.Entity.Migrations;

namespace DbEntities.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DbEntities.SoftuniStoreContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DbEntities.SoftuniStoreContext context)
        {
        }
    }
}

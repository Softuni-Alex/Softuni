namespace GringottsDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Towns : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Name);
            
            AddColumn("dbo.Users", "BornTown", c => c.String());
            AddColumn("dbo.Users", "LivingTown", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "LivingTown");
            DropColumn("dbo.Users", "BornTown");
            DropTable("dbo.Towns");
        }
    }
}

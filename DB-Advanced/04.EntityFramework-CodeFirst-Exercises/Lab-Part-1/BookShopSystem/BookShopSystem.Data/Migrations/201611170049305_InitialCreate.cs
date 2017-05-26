namespace BookShopSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Authors",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(),
                    LastName = c.String(),
                })
                .PrimaryKey(t => t.Id);

            this.CreateTable(
                "dbo.Books",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(maxLength: 50),
                    Descripton = c.String(maxLength: 1000),
                    EditionType = c.Int(nullable: false),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Copies = c.Int(nullable: false),
                    ReleaseDate = c.DateTime(nullable: false),
                    Author_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.Author_Id)
                .Index(t => t.Author_Id);

            this.CreateTable(
                "dbo.Categories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Book_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .Index(t => t.Book_Id);

        }

        public override void Down()
        {
            this.DropForeignKey("dbo.Categories", "Book_Id", "dbo.Books");
            this.DropForeignKey("dbo.Books", "Author_Id", "dbo.Authors");
            this.DropIndex("dbo.Categories", new[] { "Book_Id" });
            this.DropIndex("dbo.Books", new[] { "Author_Id" });
            this.DropTable("dbo.Categories");
            this.DropTable("dbo.Books");
            this.DropTable("dbo.Authors");
        }
    }
}

namespace DbEntities.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ReCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Trailer", c => c.String());
            DropColumn("dbo.Games", "YoutubeVideoId");
        }

        public override void Down()
        {
            AddColumn("dbo.Games", "YoutubeVideoId", c => c.Int(nullable: false));
            DropColumn("dbo.Games", "Trailer");
        }
    }
}

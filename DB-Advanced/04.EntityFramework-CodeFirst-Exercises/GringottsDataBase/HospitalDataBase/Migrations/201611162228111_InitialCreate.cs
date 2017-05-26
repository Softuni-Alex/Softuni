namespace HospitalDataBase.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Diagnoses",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Comment = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            this.CreateTable(
                "dbo.Medicaments",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            this.CreateTable(
                "dbo.Patients",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(nullable: false),
                    LastName = c.String(nullable: false),
                    Email = c.String(nullable: false),
                    DateOfBirth = c.DateTime(nullable: false),
                    Picture = c.Binary(nullable: false),
                    MedicalInsurance = c.Boolean(nullable: false),
                    Diagnose_Id = c.Int(nullable: false),
                    Medicament_Id = c.Int(nullable: false),
                    Visitation_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diagnoses", t => t.Diagnose_Id, cascadeDelete: true)
                .ForeignKey("dbo.Medicaments", t => t.Medicament_Id, cascadeDelete: true)
                .ForeignKey("dbo.Visitations", t => t.Visitation_Id, cascadeDelete: true)
                .Index(t => t.Diagnose_Id)
                .Index(t => t.Medicament_Id)
                .Index(t => t.Visitation_Id);

            this.CreateTable(
                "dbo.Visitations",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Date = c.DateTime(nullable: false),
                    Comments = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            this.DropForeignKey("dbo.Patients", "Visitation_Id", "dbo.Visitations");
            this.DropForeignKey("dbo.Patients", "Medicament_Id", "dbo.Medicaments");
            this.DropForeignKey("dbo.Patients", "Diagnose_Id", "dbo.Diagnoses");
            this.DropIndex("dbo.Patients", new[] { "Visitation_Id" });
            this.DropIndex("dbo.Patients", new[] { "Medicament_Id" });
            this.DropIndex("dbo.Patients", new[] { "Diagnose_Id" });
            this.DropTable("dbo.Visitations");
            this.DropTable("dbo.Patients");
            this.DropTable("dbo.Medicaments");
            this.DropTable("dbo.Diagnoses");
        }
    }
}
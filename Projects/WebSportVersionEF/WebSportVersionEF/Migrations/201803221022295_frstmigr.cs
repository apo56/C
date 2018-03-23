namespace WebSportVersionEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class frstmigr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Competitor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Email = c.String(),
                        DateNaissance = c.DateTime(),
                        Race_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Race", t => t.Race_Id, cascadeDelete: true)
                .Index(t => t.Race_Id);
            
            CreateTable(
                "dbo.Race",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        Organizer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizer", t => t.Organizer_Id, cascadeDelete: true)
                .Index(t => t.Organizer_Id);
            
            CreateTable(
                "dbo.Organizer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Email = c.String(),
                        DateNaissance = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Competitor", "Race_Id", "dbo.Race");
            DropForeignKey("dbo.Race", "Organizer_Id", "dbo.Organizer");
            DropIndex("dbo.Race", new[] { "Organizer_Id" });
            DropIndex("dbo.Competitor", new[] { "Race_Id" });
            DropTable("dbo.Organizer");
            DropTable("dbo.Race");
            DropTable("dbo.Competitor");
        }
    }
}

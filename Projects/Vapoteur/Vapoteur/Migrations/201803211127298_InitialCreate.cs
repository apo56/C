namespace Vapoteur.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accumulateurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Marque = c.String(),
                        DechargeMax = c.Int(nullable: false),
                        Capacité = c.Int(nullable: false),
                        Box_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Boxes", t => t.Box_Id)
                .Index(t => t.Box_Id);
            
            CreateTable(
                "dbo.Boxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Marque = c.String(),
                        PuissanceMax = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accumulateurs", "Box_Id", "dbo.Boxes");
            DropIndex("dbo.Accumulateurs", new[] { "Box_Id" });
            DropTable("dbo.Boxes");
            DropTable("dbo.Accumulateurs");
        }
    }
}

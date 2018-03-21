namespace Vapotage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class FirstMigratio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accumulateur",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Marque = c.String(),
                    DechargeMax = c.Int(),
                    Capacite = c.Int(nullable: false),
                    Box_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Box", t => t.Box_Id)
                .Index(t => t.Box_Id);

            CreateTable(
                "dbo.Box",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Marque = c.String(),
                    PuissanceMAX = c.Int(),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Accumulateur", "Box_Id", "dbo.Box");
            DropIndex("dbo.Accumulateur", new[] { "Box_Id" });
            DropTable("dbo.Box");
            DropTable("dbo.Accumulateur");
        }
    }
}

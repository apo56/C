namespace TESTNOOB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arrow",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Bow_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bow", t => t.Bow_Id)
                .Index(t => t.Bow_Id);
            
            CreateTable(
                "dbo.Bow",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Arrow", "Bow_Id", "dbo.Bow");
            DropIndex("dbo.Arrow", new[] { "Bow_Id" });
            DropTable("dbo.Bow");
            DropTable("dbo.Arrow");
        }
    }
}

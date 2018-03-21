namespace Vapoteur.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Boxes", newName: "TestBoxes");
            RenameColumn(table: "dbo.Accumulateurs", name: "Box_Id", newName: "TestBox_Id");
            RenameIndex(table: "dbo.Accumulateurs", name: "IX_Box_Id", newName: "IX_TestBox_Id");
            DropColumn("dbo.TestBoxes", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TestBoxes", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            RenameIndex(table: "dbo.Accumulateurs", name: "IX_TestBox_Id", newName: "IX_Box_Id");
            RenameColumn(table: "dbo.Accumulateurs", name: "TestBox_Id", newName: "Box_Id");
            RenameTable(name: "dbo.TestBoxes", newName: "Boxes");
        }
    }
}

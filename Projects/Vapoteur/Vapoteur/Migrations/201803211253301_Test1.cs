namespace Vapoteur.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Boxes", "Nom", c => c.String());
            AddColumn("dbo.Boxes", "Test", c => c.String());
            AddColumn("dbo.Boxes", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Boxes", "Discriminator");
            DropColumn("dbo.Boxes", "Test");
            DropColumn("dbo.Boxes", "Nom");
        }
    }
}

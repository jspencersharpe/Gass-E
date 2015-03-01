namespace GassE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class App : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "MPG");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "MPG", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}

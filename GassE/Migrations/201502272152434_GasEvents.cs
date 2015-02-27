namespace GassE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GasEvents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "MPG", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "MPG");
        }
    }
}

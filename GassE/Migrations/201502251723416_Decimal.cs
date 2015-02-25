namespace GassE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Decimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Gallons", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Events", "CostofFillUp", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "CostofFillUp", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "Gallons", c => c.Int(nullable: false));
        }
    }
}

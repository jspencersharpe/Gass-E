namespace GassE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHashField : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Odometer = c.Int(nullable: false),
                        Gallons = c.Decimal(nullable: false),
                        CostofFillUp = c.Decimal(nullable: false),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}

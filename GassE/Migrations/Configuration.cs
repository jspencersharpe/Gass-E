namespace GassE.Migrations
{
    using GassE.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GassE.EventContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GassE.EventContext context)
        {
            context.Events.AddOrUpdate<Model.Event>(
                    n => n.Odometer,
                    new Event { Odometer = 200000, Gallons = 10, CostofFillUp = 50, Date = "10/01/2015" }
                );

         
        }
    }
}

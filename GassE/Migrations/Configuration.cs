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
            ContextKey = "GassE.EventContext";
        }

        protected override void Seed(GassE.EventContext context)
        {
            context.Events.AddOrUpdate<Model.Event>(
                    n => n.Odometer,
                    new Event { Odometer = 200000, Gallons = 10, CostofFillUp = 50, Date = "10/01/2015" }
                );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}

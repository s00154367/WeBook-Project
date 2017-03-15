namespace WebCreateQR.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebCreateQR.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebCreateQR.Models.ApplicationDbContext context)
        {
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

            context.Events.AddOrUpdate(
                e => e.EventId,
                new Event { EventId = 1, EventName = "Paddy's Day", EventLocation = "Sligo", StartDateTime = DateTime.Parse("17-03-2017"), EndDateTime = DateTime.Parse("18/03/2017"), TicketsAvailable = 200, RemainingTickets = 150 },
                new Event { EventId = 2, EventName = "Conventions", EventLocation = "Dublin", StartDateTime = DateTime.Parse("24-03-2017"), EndDateTime = DateTime.Parse("24/03/2017"), TicketsAvailable = 200, RemainingTickets = 150 },
                new Event { EventId = 3, EventName = "Bird Talk", EventLocation = "Sligo", StartDateTime = DateTime.Parse("20-03-2017"), EndDateTime = DateTime.Parse("20/03/2017"), TicketsAvailable = 200, RemainingTickets = 150 }
                );
        }
    }
}

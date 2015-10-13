namespace AdareCode.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AdareCode.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AdareCode.DAL.AdareContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AdareCode.DAL.AdareContext context)
        {
            var eventypes = new List<EventType>
            {                
                new EventType { Id = 1, Description = "Print Show" },
                new EventType { Id = 2, Description = "Email Show" },
                new EventType { Id = 3, Description = "Fax Show" }
            };

            eventypes.ForEach( e => context.EventTypes.AddOrUpdate(p => p.Description, e));

            var shows = new List<AdareShow>
            {
                new AdareShow {EventDate = new DateTime(2015, 5, 15), EventTypeId = 1},
                new AdareShow {EventDate = new DateTime(2015, 5, 23), EventTypeId = 1},
                new AdareShow {EventDate = new DateTime(2015, 5, 16), EventTypeId = 2},
                new AdareShow {EventDate = new DateTime(2015, 5, 17), EventTypeId = 2},
                new AdareShow {EventDate = new DateTime(2015, 5, 18), EventTypeId = 3}
            };

            shows.ForEach(s => context.AdareShows.AddOrUpdate(p => p.EventDate, s));
        }
    }
}

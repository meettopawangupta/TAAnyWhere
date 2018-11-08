namespace TADBAccess.Migrations
{
    using DomainModels.Entites;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
   

    internal sealed class Configuration : DbMigrationsConfiguration<TADBAccess.TAAnywhereDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TADBAccess.TAAnywhereDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            TATravelType _TravelType1 = new TATravelType { TravelType = "Domestic", TravelTypeDescirption = "Domestic Travel" };
            TATravelType _TravelType2 = new TATravelType { TravelType = "International", TravelTypeDescirption = "International Travel" };

            if (context.TATravelTypes.Where(x => x.TravelType == "Domestic") == null)
                context.TATravelTypes.AddOrUpdate(_TravelType1);
        
            if (context.TATravelTypes.Where(x => x.TravelType == "International") == null)
                context.TATravelTypes.AddOrUpdate(_TravelType2);
    
            TAPurpose _TAPurpose1 = new TAPurpose { TravelPurpose  = "ClientMeeting", TravelPurposeDescirption  = "Client Meeting" };
            TAPurpose _TAPurpose2 = new TAPurpose { TravelPurpose = "Conference", TravelPurposeDescirption = "Conference" };

            if (context.TAPurposes.Where(x => x.TravelPurpose == "ClientMeeting") == null)
                context.TAPurposes.AddOrUpdate(_TAPurpose1);

            if (context.TAPurposes.Where(x => x.TravelPurpose == "Conference") == null)
                context.TAPurposes.AddOrUpdate(_TAPurpose2);

            context.SaveChanges();

        }
    }
}


using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using TraningSessionApi.Entities;

namespace TraningSessionApi.Infrastructur.Data
{
    public class SeedData
    {

        public static void SeedDatabase(SessionContext context)
        {

            if (!context.Sessions.Any())
            {
                var session1 = new Session
                {
                    ClayPigions = 24,
                    NumberOfShots = 30,
                    Duble = true,
                    HowWasPigonHit = 1
                };
                var session2 = new Session
                {
                    ClayPigions = 40,
                    NumberOfShots = 60,
                    Duble = true,
                    HowWasPigonHit = 2
                };
                context.Sessions.AddRange(session1, session2);

                context.SaveChanges();
            }

        }
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedDatabase(serviceScope.ServiceProvider.GetService<SessionContext>());
            }
        }
    //    public static void SeedDatabase(SessionContext context)
    //    {
    //        var claypigions = Faker.Enum.Random<ClaypigionsEnum>();
    //        var duble = Faker.RandomNumber.Next(1, 2);
    //        var numberOfShorts = Faker.RandomNumber.Next(24, 60);
    //        var howWasPigonHit = Faker.Enum.Random<HowWasPigonHitEnum>();

    //        List<Session> session = new List<Session>();

    //        for (int i = 0; i < 5; i++)
    //        {
    //            var fakeSession = new Faker<Session>()
    //                .RuleFor(z => z.ClayPigions, z => (int)claypigions)
    //                .RuleFor(z => z.NumberOfShots, z => numberOfShorts);

    //            var sessionFaker = JsonSerializer.Serialize(fakeSession);
    //            session.Add(fakeSession);

    //        }

    //        context.Sessions.AddRange(session);
    //        context.SaveChanges();


    //    }
     
        
    //    public enum ClaypigionsEnum
    //    {
    //        lille = 24,
    //        stor = 40
    //    }

    //    public enum HowWasPigonHitEnum
    //    {
    //        Første,
    //        Anden,
    //        Begge

    //    }

    }
}


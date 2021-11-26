
using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using TraningSessionApi.Entities;

namespace TraningSessionApi.Infrastructur.Data
{
    public class SeedData
    {

        //public static void PrepPopulation(IApplicationBuilder app)
        //{
        //    using (var serviceScope = app.ApplicationServices.CreateScope())
        //    {
        //        SeedDatabase(serviceScope.ServiceProvider.GetService<SessionContext>());
        //    }
        //}
        public static void SeedDatabase(SessionContext context)
        {
            var claypigions = Faker.Enum.Random<ClaypigionsEnum>();
            var duble = Faker.RandomNumber.Next(1, 2);
            var numberOfShorts = Faker.RandomNumber.Next(40, 88);
            var howWasPigonHit = Faker.Enum.Random<HowWasPigonHitEnum>();

            List<Session> session = new List<Session>();

            for (int i = 0; i < 5; i++)
            {
                var fakeSession = new Faker<Session>()
                    .RuleFor(z => z.ClayPigions, z => (int)claypigions)
                    .RuleFor(z => z.NumberOfShots, z => numberOfShorts);

                var sessionFaker = JsonSerializer.Serialize(fakeSession);
                session.Add(fakeSession);
                Thread.Sleep(20);
                

            }

            context.Sessions.AddRange(session);
            context.SaveChanges();


        }


        public enum ClaypigionsEnum
        {
            lille = 24,
            stor = 40
        }

        public enum HowWasPigonHitEnum
        {
            Første,
            Anden,
            Begge

        }

    }
}


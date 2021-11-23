
using System.Linq;

using TraningSessionApi.Entities;

namespace TraningSessionApi.Infrastructur.Data
{
    public class SeedData
    {
     
        public static void SeedDatabase(SessionContext context)
        {

            if(!context.Sessions.Any())
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

    }
}


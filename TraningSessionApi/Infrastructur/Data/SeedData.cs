using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraningSessionApi.Entities;

namespace TraningSessionApi.Infrastructur.Data
{
    public class SeedData
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedDatabase(serviceScope.ServiceProvider.GetService<SessionContext>());
            }
        }
        public static void SeedDatabase(SessionContext context)
        {

            if (!context.Sessions.Any())
            {
                context.Sessions.AddRange(
                    new Session() {  ClayPigions = 40, Duble=true, NumberOfShots=24  },
                    new Session() {ClayPigions= 24, Duble= false, NumberOfShots=20 },
                    new Session() {ClayPigions=24, Duble=true,NumberOfShots=24 }

                    );  ;
                context.SaveChanges();
            }

        }

    }
}

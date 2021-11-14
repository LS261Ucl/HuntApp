using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

using WeatherApi.Entities;

namespace WeatherApi.Infrastructure.Data
{
    public static class SeedData
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedDatabase(serviceScope.ServiceProvider.GetService<WeatherContext>());
            }
        }

        public static void SeedDatabase(WeatherContext context)
        {
            if(context.Weathers.Any())
            {
                context.Weathers.AddRange(
                    new Weather() { Rain="Støvregn", Wind="roligt"},
                    new Weather() { Wind="Side vind højre", Rain="Ingen", sun="letover skyet"},
                    new Weather() { Rain="Ingen", sun="Høj Sol", Wind="let brise"}
                    );

                context.SaveChanges();
            }
        }
    }
}

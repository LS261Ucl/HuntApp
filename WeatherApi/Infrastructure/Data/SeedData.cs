using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

using WeatherApi.Entities;

namespace WeatherApi.Infrastructure.Data
{
    public static class SeedData
    {
        public static void SeedDatabase(WeatherContext context)
        {
           if(context.Weathers.Any())
            {
                context.Weathers.AddRange(
                    new Weather() { Rain="Støvregn", Wind="roligt"},
                    new Weather() { Wind="Side vind højre", Rain="Ingen", Sun="letover skyet"},
                    new Weather() { Rain="Ingen", Sun="Høj Sol", Wind="let brise"}
                    );

                context.SaveChanges();
            }
        }
    }
}

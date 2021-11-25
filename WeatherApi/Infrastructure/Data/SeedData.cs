using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
            var regn = Faker.Enum.Random<Rain>();
            var vind = Faker.Enum.Random<Wind>();
            var sol = Faker.Enum.Random<Sun>();

            List<Weather> weathers = new List<Weather>();

            for (int i = 0; i < 50; i++)
            {
                var fakeWeather = new Faker<Weather>()
                .RuleFor(z => z.Rain, z => regn.ToString())
                .RuleFor(z => z.Wind, z => vind.ToString())
                .RuleFor(z => z.Sun, z => sol.ToString());

                var weatherFaker = JsonSerializer.Serialize(fakeWeather.Generate());
                weathers.Add(fakeWeather);
            }

            context.Weathers.AddRange(weathers);

            context.SaveChanges();


        }

    }

    public enum Rain
    {
        HelDagsRegn,
        SillendeRegn,
        Drypper

    }

    public enum Wind
    {
        Kuling,
        Hård,
        Blæse,
        Brise
    }

    public enum Sun
    {
        OverSkyet,
        Skyetmedsol,
        Sol
    }
}

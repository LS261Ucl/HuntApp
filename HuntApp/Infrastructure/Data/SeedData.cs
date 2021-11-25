using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using UserApi.Entities;

namespace UserApi.Infrastructure.Data
{
    public static class SeedData
    {
        //public static void PrepPopulation(IApplicationBuilder app)
        //{
        //    using(var serviceScope = app.ApplicationServices.CreateScope())
        //    {
        //        SeedDatabase(serviceScope.ServiceProvider.GetService<UserContext>());
        //    }
        //}
        public static void SeedDatabase(UserContext context)
        {

            //List<User> users = new List<User>();
            //List<Weapon> weapons = new List<Weapon>();
            //used for add range, but did not work
            for (int i = 0; i < 1; i++)
            {
                var id = Guid.NewGuid(); 
                var userId = Guid.NewGuid();
                var UserFaker = new Faker<User>()
                .RuleFor(x => x.Name, x => x.Person.FullName)
                .RuleFor(x => x.Email, x => x.Person.Email)
                //.RuleFor(x => x.UserId, x => userId)
                .RuleFor(x => x.PhoneNumber, x => x.Phone.Locale);
                var userFake = JsonSerializer.Serialize(UserFaker.Generate());
                context.Users.Add(UserFaker);


                //random number 1-4 
                int randomNumber = Faker.RandomNumber.Next(1, 4);


                var favorit = false;
                for (int y = 0; y < randomNumber; y++)
                {
                    var weaponType = Faker.Enum.Random<WeaponTypeEnum>();
                    var caliber = Faker.Enum.Random<CaliberEnum>();

                    if (y == 0)
                    {
                        favorit = true;
                    }

                    var userWeapons = new Faker<Weapon>()
                    .RuleFor(j => j.Type, j => weaponType.ToString())
                    .RuleFor(j => j.Caliber, j => ((int)caliber).ToString())
                    .RuleFor(j => j.Favorit, j => favorit)                    
                    .RuleFor(j => j.UserId, j => id);
                    var UserWeapons = JsonSerializer.Serialize(userWeapons.Generate());
                    Console.WriteLine(UserWeapons);
                    context.Weapons.Add(userWeapons);
                    context.SaveChanges();

                }
                int countWeapons = context.Weapons.Count();

                context.SaveChanges();

            }

        }
    }

    public enum WeaponTypeEnum
    {
        SideBySide,
        OverUnder,
        HalvAutomatisk
    }

    public enum CaliberEnum
    {
        Caliber12 = 12,
        Caliber16 = 16,
        Caliber20 = 20,
        Caliber410 = 410
    }
}

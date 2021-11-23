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
        //public static void SeedDatabase(UserContext context)
        //{

        //    if (!context.Users.Any() && !context.Weapons.Any())
        //    {
        //        var user1 =
        //            new User() { Name = "Thor Odiensøn", Email = "to@gmail.com", PhoneNumber = "11223344" };
        //        var user2 =
        //            new User() { Name = "Dot Net", Email = "ms@gmail.com", PhoneNumber = "44556677" };
        //        var user3 =
        //            new User() { Name = "Apollo Zeus", Email = "ae@gmail.com", PhoneNumber = "12345678" };

        //        context.Users.AddRange(user1, user2, user3);

        //        var weapon1 =
        //              new Weapon() { Type = "Sidebyside", Caliber = "12" };
        //        var weapon2 = new Weapon() { Type = "Singel", Caliber = "13" };
        //        var weapon3 = new Weapon() { Type = "Semi", Caliber = "12" };

        //        context.Weapons.AddRange(weapon1, weapon2, weapon3);



        //        context.SaveChanges();

        //    }

        //}

        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedDatabase(serviceScope.ServiceProvider.GetService<UserContext>());
            }
        }
        private static void SeedDatabase(UserContext context)
        {

            List<User> users = new List<User>();
            List<Weapon> weapons = new List<Weapon>();
            for (int i = 0; i < 5; i++)
            {
                var userId = Guid.NewGuid();
                var UserFaker = new Faker<User>()
                .RuleFor(x => x.Name, x => x.Person.FullName)
                .RuleFor(x => x.Email, x => x.Person.Email)
                .RuleFor(x => x.Id, x => userId)
                .RuleFor(x => x.PhoneNumber, x => x.Phone.Locale);
                var userFake = JsonSerializer.Serialize(UserFaker.Generate());
                users.Add(UserFaker);


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
                    .RuleFor(j => j.Id, j => Guid.NewGuid())
                    .RuleFor(j => j.UserId, j => userId);
                    var UserWeapons = JsonSerializer.Serialize(userWeapons.Generate());
                    Console.WriteLine(UserWeapons);
                    weapons.Add(userWeapons);


                }
                context.Users.AddRange(users);
                context.Weapons.AddRange(weapons);

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

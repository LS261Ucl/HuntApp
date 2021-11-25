using Bogus;
using System;
using System.Collections.Generic;
using System.Text.Json;
using UserApi.Entities;

namespace UserApi.Infrastructure.Data.FakeData
{
    public static class FakeUser
    {
        public  static void SeedData(UserContext context)
        {
            
            List<User> users = new List<User>();
            List<Weapon> weapons = new List<Weapon>();
            for (int i = 0; i<5;i++ )
            {
                var userId = Guid.NewGuid();
                var faker = new Faker<User>()
                .RuleFor(x => x.Name, x => x.Person.FullName)
                .RuleFor(x => x.Email, x => x.Person.Email)
                .RuleFor(x=> x.UserId, x=> userId)
                .RuleFor(x => x.PhoneNumber, x => x.Phone.Locale);
                var userFake = JsonSerializer.Serialize(faker.Generate());
                users.Add(faker);
                
               
                //random number 1-4 
                int randomNumber = Faker.RandomNumber.Next(1, 4);
                

                var favorit = false;
                for (int y=0;y< randomNumber;y++)
                {
                    var weaponType = Faker.Enum.Random<WeaponTypeEnum>();
                    var caliber = Faker.Enum.Random<CaliberEnum>();
                    if (y == 0)
                    {
                        favorit = true;
                    }
                    var fakerWeapon = new Faker<Weapon>()
                    .RuleFor(j => j.Type, j => weaponType.ToString())
                    .RuleFor(j => j.Caliber, j => ((int)caliber).ToString())
                    .RuleFor(j => j.Favorit, j => favorit)
                    
                    .RuleFor(j => j.UserId, j => userId);
                    var UserWeapons = JsonSerializer.Serialize(fakerWeapon.Generate());
                    Console.WriteLine(UserWeapons);
                    weapons.Add(fakerWeapon);               


                }
                context.Users.AddRange(users);
                context.Weapons.AddRange(weapons);
               
                context.SaveChanges();

            }

        }
    }
}

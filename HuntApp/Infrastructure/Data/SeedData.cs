using System.Linq;
using UserApi.Entities;

namespace UserApi.Infrastructure.Data
{
    public static class SeedData
    {
        public static void SeedDatabase(UserContext context)
        {

            if (!context.Users.Any() && !context.Weapons.Any())
            {
                var user1 =
                    new User() { Name = "Thor Odiensøn", Email = "to@gmail.com", PhoneNumber = "11223344" };
                var user2 =
                    new User() { Name = "Dot Net", Email = "ms@gmail.com", PhoneNumber = "44556677" };
                var user3 =
                    new User() { Name = "Apollo Zeus", Email = "ae@gmail.com", PhoneNumber = "12345678" };

                context.Users.AddRange(user1, user2, user3);

                var weapon1 =
                      new Weapon() { Type = "Sidebyside", Caliber = "12" };
                var weapon2 = new Weapon() { Type = "Singel", Caliber = "13" };
                var weapon3 = new Weapon() { Type = "Semi", Caliber = "12" };

                context.Weapons.AddRange(weapon1, weapon2, weapon3);



                context.SaveChanges();

            }

        }

    }
}

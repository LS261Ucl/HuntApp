using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApi.Entities;

namespace UserApi.Infrastructure.Data
{
    public static class IdentitySeedData
    {
        public static async Task SeedIndentityDatabase(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        Name = "Lene Svit", UserName = "Lsvit", Email = "lsvit@gmail.com"
                    },
                    new AppUser
                    {
                        Name = "Carsten Nielsen", UserName = "CarNiels", Email = "carniels@gmail.com"
                    },
                };

                foreach(var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
        }
    }
}

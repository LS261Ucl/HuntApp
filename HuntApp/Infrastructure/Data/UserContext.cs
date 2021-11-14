using Microsoft.EntityFrameworkCore;
using UserApi.Entities;

namespace UserApi.Infrastructure.Data
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        public DbSet<User> Users  { get; set; }
        public DbSet<Weapon> Weapons { get; set; }


    }
}

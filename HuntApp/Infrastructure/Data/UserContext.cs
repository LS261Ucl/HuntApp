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

        public DbSet<AppUser> AppUsers { get; set; }

        //lave en modelbuilder til at forbinde våben på bruger via UserId???? kan det løse udfordringen.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().ToTable("AppUsers");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Weapon>().ToTable("Weapons");
        }
    }
}

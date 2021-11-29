using Microsoft.EntityFrameworkCore;
using WeatherApi.Entities;

namespace WeatherApi.Infrastructure.Data
{
    public class WeatherContext: DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
        {

        }

        public DbSet<Weather> Weathers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Weather>().ToTable("Weather");
            
        }


    }
}

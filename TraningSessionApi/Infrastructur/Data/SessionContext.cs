using Microsoft.EntityFrameworkCore;
using TraningSessionApi.Entities;

namespace TraningSessionApi.Infrastructur.Data
{
    public class SessionContext : DbContext
    {
        public SessionContext(DbContextOptions<SessionContext>options) : base(options)
        {

        }

        public DbSet<Session> Sessions { get; set; }
        //public DbSet<User> Users { get; set; }
    }
}

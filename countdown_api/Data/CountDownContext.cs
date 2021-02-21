using countdown_api.Data.Tables;
using Microsoft.EntityFrameworkCore;

namespace countdown_api.Data
{
    public class CountDownContext : DbContext
    {
        public CountDownContext()
        {
        }

        public CountDownContext(DbContextOptions<CountDownContext> options) : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<Event> Event { get; set; }

    }
}
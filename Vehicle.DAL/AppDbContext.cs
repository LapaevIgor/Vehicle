using Microsoft.EntityFrameworkCore;
using Vehicle.DAL.Models;

namespace Vehicle.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
            Database.Migrate();
        }

        DbSet<User> Users { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
        }
    }
}
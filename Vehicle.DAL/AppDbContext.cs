using Microsoft.EntityFrameworkCore;
using Vehicle.DAL.Entities;

namespace Vehicle.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
            Database.Migrate();
        }

        DbSet<UserDb> Users { get;set; }
        DbSet<UserPhoneNumberDb> UserPhoneNumbers { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDb>();
            modelBuilder.Entity<UserPhoneNumberDb>()
                .HasOne(u => u.User);
        }
    }
}
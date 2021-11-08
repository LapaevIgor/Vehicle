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

        public DbSet<UserDb> Users { get;set; }
        public DbSet<UserPhoneNumberDb> UserPhoneNumbers { get;set; }
        public DbSet<CarBrandDb> CarBrands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDb>();
            modelBuilder.Entity<UserPhoneNumberDb>()
                .HasOne(u => u.User);
            modelBuilder.Entity<CarBrandDb>()
                .HasMany(u => u.User);
        }
    }
}
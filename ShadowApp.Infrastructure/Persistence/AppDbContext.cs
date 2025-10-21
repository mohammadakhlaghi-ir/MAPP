using Microsoft.EntityFrameworkCore;
using ShadowApp.Domain.Entities;

namespace ShadowApp.Infrastructure.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Log> Logs => Set<Log>();
        public DbSet<Setting> Settings => Set<Setting>();
        public DbSet<Language> Languages => Set<Language>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Setting>()
                .HasOne(s => s.Language)
                .WithOne(l => l.Setting)
                .HasForeignKey<Setting>(s => s.LanguageID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
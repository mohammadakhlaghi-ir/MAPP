using Microsoft.EntityFrameworkCore;
using MAPP.Domain.Entities;

namespace MAPP.Infrastructure.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Log> Logs => Set<Log>();
    }
}
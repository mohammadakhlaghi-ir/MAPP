using Microsoft.EntityFrameworkCore;

namespace MAPP.Infrastructure.Persistence.Seed
{
    public static class DatabaseSeeder
    {
        public static void SeedAdminUser(this AppDbContext dbContext)
        {
            dbContext.Database.Migrate();

            if (!dbContext.Users.Any())
            {
                var adminUser = new Domain.Entities.User
                {
                    Name = "admin",
                    Password = "Admin@123",
                    Email = "admin@example.com",
                    FirstName = "System",
                    LastName = "Admin",
                    Creator = "System"
                };

                dbContext.Users.Add(adminUser);
                dbContext.SaveChanges();
            }
        }
    }
}
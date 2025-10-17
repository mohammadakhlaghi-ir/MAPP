using MAPP.Application.Utilities;
using MAPP.Domain.Entities;
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
                var adminUser = new User
                {
                    Name = "admin",
                    Password = "Admin@123",
                    Email = "admin@example.com",
                    FirstName = "System",
                    LastName = "Admin",
                    Creator = "System"
                };

                adminUser.Crc = CrcHelper.ComputeCrc($"{adminUser.Name}|{adminUser.Email}|{adminUser.FirstName}" +
                    $"|{adminUser.LastName}|0|1|{adminUser.CreateDate:O}|{adminUser.Creator}|{adminUser.ModifyDate:O}" +
                    $"|{adminUser.Modifier}");

                dbContext.Users.Add(adminUser);
                dbContext.SaveChanges();
            }
        }
    }
}
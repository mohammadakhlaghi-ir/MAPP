using MAPP.Application.Utilities;
using MAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MAPP.Infrastructure.Persistence.Seed
{
    public static class DatabaseSeeder
    {
        public static void SeedAdminUser(this AppDbContext context)
        {
            context.Database.Migrate();

            if (!context.Users.Any())
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

                context.Users.Add(adminUser);
                context.SaveChanges();
            }

            if (!context.Settings.Any())
            {
                var setting = new Setting();
                setting.Crc = CrcHelper.ComputeCrc($"{setting.Language}|{setting.ModifyDate:O}");
                context.Settings.Add(setting);
                context.SaveChanges();
            }
        }
    }
}
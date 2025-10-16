using MAPP.Infrastructure.Persistence;
using MAPP.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MAPP.Infrastructure.Extensions
{
    public static class DatabaseServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var encryptionKey = configuration["EncryptionKey"] ?? "12345678901234567890123456789012";
            var encryptionService = new EncryptionService(encryptionKey);
            var dbSection = configuration.GetSection("DatabaseSettings");
            var serverName = dbSection["ServerName"] ?? throw new InvalidOperationException("ServerName is missing");
            var databaseName = dbSection["DatabaseName"] ?? throw new InvalidOperationException("DatabaseName is missing");
            var userName = dbSection["UserName"] ?? throw new InvalidOperationException("UserName is missing");
            var encryptedPassword = dbSection["Password"] ?? throw new InvalidOperationException("Password is missing");
            var encrypt = bool.TryParse(dbSection["Encrypt"], out var e) && e;
            var trustServerCertificate = bool.TryParse(dbSection["TrustServerCertificate"], out var t) && t;
            var password = encryptionService.Decrypt(encryptedPassword);
            var connectionString =
                $"Server={serverName};Database={databaseName};User Id={userName};" +
                $"Password={password};Encrypt={encrypt};TrustServerCertificate={trustServerCertificate};";

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}

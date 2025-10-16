using MAPP.Application.DTOs;
using MAPP.Application.Interfaces;
using MAPP.Infrastructure.Persistence;
using MAPP.Infrastructure.Persistence.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MAPP.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task UseInfrastructureSeedAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var logService = scope.ServiceProvider.GetRequiredService<ILogService>();

            try
            {
                dbContext.SeedAdminUser();

                await logService.AddLog(new AddLogDto
                {
                    Title = "Application Started",
                    Description = $"App started successfully at {DateTime.Now}"
                });
            }
            catch (Exception ex)
            {
                await logService.AddLog(new AddLogDto
                {
                    Title = "Startup Error",
                    Description = ex.ToString()
                });
                throw;
            }
        }
    }
}

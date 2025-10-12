using MAPP.Application.Interfaces;
using MAPP.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MAPP.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ILogService, LogService>();

            return services;
        }
    }
}

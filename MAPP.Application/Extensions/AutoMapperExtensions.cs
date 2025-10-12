using MAPP.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace MAPP.Application.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddApplicationMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<LogProfile>();
            });

            return services;
        }
    }
}

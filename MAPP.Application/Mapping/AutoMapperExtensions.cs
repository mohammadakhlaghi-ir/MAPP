using Microsoft.Extensions.DependencyInjection;

namespace MAPP.Application.Mapping
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

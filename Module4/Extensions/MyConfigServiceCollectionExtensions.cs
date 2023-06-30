using Module4.DI;
using Module4.Models;

namespace Module4.Extensions
{
    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddConfig(this IServiceCollection services,
            IConfiguration config)
        {
            services.Configure<PositionOptions>(
                config.GetSection(PositionOptions.Position));
            services.Configure<ColorOptions>(
                config.GetSection(ColorOptions.Color));
            return services;
        }
        public static IServiceCollection AddDIs(this IServiceCollection services)
        {
            services.AddScoped<IMyDependency, MyDependency>();
            return services;
        }
    }
}

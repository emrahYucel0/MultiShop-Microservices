using Microsoft.Extensions.Options;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Extentions;

public static class DatabaseConfigurationExtensions
{
    public static void ConfigureDatabaseSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));
        services.AddScoped<IDatabaseSettings>(sp =>
        {
            return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
        });
    }
}

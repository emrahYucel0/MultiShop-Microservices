using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MultiShop.Catalog.Extentions;

public static class AuthenticationServiceExtensions
{
    public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
        {
            opt.Authority = configuration["IdentityServerUrl"];
            opt.Audience = "ResourceCatalog";
            opt.RequireHttpsMetadata = false;
        });
    }
}

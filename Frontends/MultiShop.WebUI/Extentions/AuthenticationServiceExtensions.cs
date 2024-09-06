using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MultiShop.WebUI.Extentions;

public static class AuthenticationServiceExtensions
{
    public static void AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
        {
            opt.LoginPath = "/Login/Index/";
            opt.LogoutPath = "/Login/LogOut/";
            opt.AccessDeniedPath = "/Pages/AccessDenied/";
            opt.Cookie.HttpOnly = true;
            opt.Cookie.SameSite = SameSiteMode.Strict;
            opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            opt.Cookie.Name = "MultiShopJwt";
        });

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
            AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
            {
                opt.LoginPath = "/Login/Index/";
                opt.ExpireTimeSpan = TimeSpan.FromDays(5);
                opt.Cookie.Name = "MultiShopCookie";
                opt.SlidingExpiration = true;
            });

        services.AddAccessTokenManagement();
    }
}

using MultiShop.WebUI.Handlers;
using MultiShop.WebUI.Services.Concrete;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Extentions
{
    public static class TokenHandlerExtensions
    {
        public static void AddTokenHandlers(this IServiceCollection services)
        {
            services.AddScoped<ResourceOwnerPasswordTokenHandler>();
            services.AddScoped<ClientCredentialTokenHandler>();
            services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();
        }
    }
}

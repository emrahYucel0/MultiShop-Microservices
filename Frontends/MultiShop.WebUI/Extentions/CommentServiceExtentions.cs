using MultiShop.WebUI.Handlers;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Settings;

namespace MultiShop.WebUI.Extentions
{
    public static class CommentServiceExtentions
    {
        public static void AddCommentServices(this IServiceCollection services, IConfiguration configuration)
        {
            var values = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

            services.AddHttpClient<ICommentService, CommentService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Comment.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        }
    }
}

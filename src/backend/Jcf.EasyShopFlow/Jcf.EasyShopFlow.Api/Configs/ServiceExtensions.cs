using Jcf.EasyShopFlow.Core.IServices;
using Jcf.EasyShopFlow.Infra.Services;

namespace Jcf.EasyShopFlow.Api.Configs
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}

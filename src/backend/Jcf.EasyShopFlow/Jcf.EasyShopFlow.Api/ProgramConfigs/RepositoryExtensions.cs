using Jcf.EasyShopFlow.Core.IRepositories;
using Jcf.EasyShopFlow.Infra.Repositories;

namespace Jcf.EasyShopFlow.Api.Configs
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddCustomRepositories(this IServiceCollection services)
        {           
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }        
    }
}

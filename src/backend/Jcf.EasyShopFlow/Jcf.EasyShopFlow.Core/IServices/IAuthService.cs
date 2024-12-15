using Jcf.EasyShopFlow.Core.Entities;

namespace Jcf.EasyShopFlow.Core.IServices
{
    public interface IAuthService
    {
        Task<User?> AuthenticateAsync(string userName, string password);
    }
}

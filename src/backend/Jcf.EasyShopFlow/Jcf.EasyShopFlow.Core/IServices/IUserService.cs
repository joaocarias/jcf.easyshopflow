using Jcf.EasyShopFlow.Core.Entities;

namespace Jcf.EasyShopFlow.Core.IServices
{
    public interface IUserService
    {
        Task<User?> GetAsync(Guid id);
        Task<User?> CreateAsync(User user);
    }
}

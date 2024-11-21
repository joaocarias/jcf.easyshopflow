using Jcf.EasyShopFlow.Core.Entities;

namespace Jcf.EasyShopFlow.Core.IServices
{
    public interface IUserService
    {
        Task<User?> Get(Guid id);
    }
}

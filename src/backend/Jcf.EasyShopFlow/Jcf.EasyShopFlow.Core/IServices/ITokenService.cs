using Jcf.EasyShopFlow.Core.Entities;
using System.Security.Claims;

namespace Jcf.EasyShopFlow.Core.IServices
{
    public interface ITokenService
    {
        ClaimsIdentity GeneratorClaims(User user);
        string NewToken(User user);
    }
}

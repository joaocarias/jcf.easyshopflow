using Jcf.EasyShopFlow.Core.Entities;
using Jcf.EasyShopFlow.Core.IServices;
using Jcf.EasyShopFlow.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Jcf.EasyShopFlow.Infra.Services
{
    public class AuthService : IAuthService
    {
        private readonly ILogger<AuthService> _logger;
        private readonly AppDbContext _appDbContext;

        public AuthService(ILogger<AuthService> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public async Task<User?> AuthenticateAsync(string userName, string password)
        {
            try
            {
                return await _appDbContext.Users
                               .AsNoTracking()
                               .SingleOrDefaultAsync(_ => _.IsActive.Equals(true) && _.Login.Equals(userName) && _.Password.Equals(password));
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(AuthService)} - {nameof(AuthenticateAsync)}] | {ex.Message}");
                return null;
            }
        }
    }
}

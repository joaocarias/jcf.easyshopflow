using Jcf.EasyShopFlow.Core.Entities;
using Jcf.EasyShopFlow.Core.IRepositories;
using Jcf.EasyShopFlow.Core.IServices;
using Microsoft.Extensions.Logging;

namespace Jcf.EasyShopFlow.Infra.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;

        public UserService(ILogger<UserService> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<User?> Get(Guid id)
        {
            try
            {
                return await _userRepository.GetAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserService)} - {nameof(Get)}] | {ex.Message}");
                return null;
            }
        }
    }
}

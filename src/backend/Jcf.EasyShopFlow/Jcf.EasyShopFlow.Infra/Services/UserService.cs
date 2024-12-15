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

        public async Task<User?> GetAsync(Guid id)
        {
            try
            {
                return await _userRepository.GetAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserService)} - {nameof(GetAsync)}] | {ex.Message}");
                return null;
            }
        }

        public async Task<User?> CreateAsync(User user)
        {
            try
            {
                return await _userRepository.CreateAsync(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserService)} - {nameof(GetAsync)}] | {ex.Message}");
                return null;
            }
        }
    }
}

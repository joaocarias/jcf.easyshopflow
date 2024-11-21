using Jcf.EasyShopFlow.Core.IRepositories;
using Microsoft.Extensions.Logging;

namespace Jcf.EasyShopFlow.Infra.Services
{
    public class UserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;

        public UserService(ILogger<UserService> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

    }
}

using Jcf.EasyShopFlow.Core.Entities;
using Jcf.EasyShopFlow.Core.IRepositories;
using Jcf.EasyShopFlow.Infra.Contexts;
using Microsoft.Extensions.Logging;

namespace Jcf.EasyShopFlow.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly AppDapperContext _appDapperContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(AppDbContext appDbContext, AppDapperContext appDapperContext, ILogger<UserRepository> logger)
        {
            _appDbContext = appDbContext;
            _appDapperContext = appDapperContext;
            _logger = logger;
        }

        public async Task<User?> CreateAsync(User entity)
        {
            try
            {
                await _appDbContext.Users.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex) 
            {
                _logger.LogError($"[{nameof(UserRepository)} - {nameof(CreateAsync)}] {ex.Message}");
                return null;
            }
        }

        public bool Delete(User entity)
        {
            try
            {
                return Update(entity) is not null;                
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserRepository)} - {nameof(Delete)}] {ex.Message}");
                return false;
            }
        }

        public Task<ICollection<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public User? Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}

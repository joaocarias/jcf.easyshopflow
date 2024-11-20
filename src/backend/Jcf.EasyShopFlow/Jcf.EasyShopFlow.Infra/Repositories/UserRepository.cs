using Jcf.EasyShopFlow.Core.Entities;
using Jcf.EasyShopFlow.Core.IRepositories;
using Jcf.EasyShopFlow.Infra.Contexts;
using Microsoft.Extensions.Logging;
using Dapper;
using Jcf.EasyShopFlow.Infra.Uties.Queries;

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

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {                                
                var result = await _appDapperContext.Connection.QueryAsync<User>(UserQuery.GET_ALL, null, _appDapperContext.Transaction);
                return result ?? Enumerable.Empty<User>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserRepository)} - {nameof(GetAllAsync)}] {ex.Message}");
                return Enumerable.Empty<User>();
            } 
        }

        public async Task<User?> GetAsync(Guid id)
        {
            try
            {               
                var result = await _appDapperContext.Connection.QueryFirstOrDefaultAsync<User>(
                    UserQuery.GET,
                    new { Id = id },
                    _appDapperContext.Transaction
                );
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserRepository)} - {nameof(GetAsync)}] {ex.Message}");
                return null;
            }
        }

        public User? Update(User entity)
        {
            try
            {
                _appDbContext.Users.Update(entity);
                _appDbContext.SaveChanges();

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserRepository)} - {nameof(Update)}] {ex.Message}");
                return null;
            }
        }
    }
}

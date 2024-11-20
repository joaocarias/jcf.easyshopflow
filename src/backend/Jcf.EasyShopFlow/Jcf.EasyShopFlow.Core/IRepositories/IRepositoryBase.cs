namespace Jcf.EasyShopFlow.Core.IRepositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T?> CreateAsync(T entity);
        bool Delete(T entity);
        Task<T?> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        T? Update(T entity);        
    }
}

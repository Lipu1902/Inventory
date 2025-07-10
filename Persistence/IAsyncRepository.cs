namespace Inventory.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T?> GetByIdAsync(int id);
    }
}

namespace Inventory.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        Task<int> Save();
    }
}

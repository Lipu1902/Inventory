namespace Inventory.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        ICustomerInfoRepository CustomerInfoRepository { get; }
        ISaleMasterRepository SaleMasterRepository { get; }
        ISaleDetailsRepository SaleDetailsRepository { get; }
        Task<int> Save();
    }
}

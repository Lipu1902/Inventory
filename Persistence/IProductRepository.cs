using Inventory.Entities;

namespace Inventory.Persistence
{
    public interface IProductRepository:IAsyncRepository<Product>
    {
    }
}

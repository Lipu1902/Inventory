using Inventory.Entities;
using Inventory.Persistence;

namespace Inventory.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(InventoryDbContext dbContext) : base(dbContext)
        {
        }
    }
}

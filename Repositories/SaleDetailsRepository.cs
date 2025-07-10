using Inventory.Entities;
using Inventory.Persistence;

namespace Inventory.Repositories
{
    public class SaleDetailsRepository : BaseRepository<SaleDetails>, ISaleDetailsRepository
    {
        public SaleDetailsRepository(InventoryDbContext dbContext) : base(dbContext)
        {
        }
    }
}

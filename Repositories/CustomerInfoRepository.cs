using Inventory.Entities;
using Inventory.Persistence;

namespace Inventory.Repositories
{
    public class CustomerInfoRepository : BaseRepository<CustomerInfo>, ICustomerInfoRepository
    {
        public CustomerInfoRepository(InventoryDbContext dbContext) : base(dbContext)
        {
        }
    }
}

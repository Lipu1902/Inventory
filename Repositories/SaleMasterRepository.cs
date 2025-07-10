using Inventory.Entities;
using Inventory.Persistence;

namespace Inventory.Repositories
{
    public class SaleMasterRepository : BaseRepository<SaleMaster>, ISaleMasterRepository
    {
        public SaleMasterRepository(InventoryDbContext dbContext) : base(dbContext)
        {
        }
    }
}

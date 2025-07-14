using Inventory.Entities;
using Inventory.Persistence;

namespace Inventory.Repositories
{
    public class UserInfoRepository : BaseRepository<UserInfo>, IUserInfoRepository
    {
        public UserInfoRepository(InventoryDbContext dbContext) : base(dbContext)
        {
        }
    }
}

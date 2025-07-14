using Inventory.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inventory
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions contextOptions) : base(contextOptions) 
        {
        
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<CustomerInfo> CustomerInformation { get; set; }
        public DbSet<SaleMaster> SaleMasters { get; set; }
        public DbSet<SaleDetails> SaleDetails { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }

        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

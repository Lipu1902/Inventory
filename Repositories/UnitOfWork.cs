using Inventory.Persistence;

namespace Inventory.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventoryDbContext _context;
        private readonly IProductRepository _productRepository;
        public UnitOfWork(InventoryDbContext context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }
        public IProductRepository ProductRepository => _productRepository??new ProductRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

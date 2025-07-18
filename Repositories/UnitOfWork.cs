﻿using Inventory.Persistence;

namespace Inventory.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventoryDbContext _context;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerInfoRepository _customerInfoRepository;
        private readonly ISaleMasterRepository _saleMasterRepository;
        private readonly ISaleDetailsRepository _saleDetailsRepository;
        private readonly IUserInfoRepository _userInfoRepository;
        public UnitOfWork(InventoryDbContext context, IProductRepository productRepository, ICustomerInfoRepository customerInfoRepository, ISaleMasterRepository saleMasterRepository, ISaleDetailsRepository saleDetailsRepository, IUserInfoRepository userInfoRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _customerInfoRepository = customerInfoRepository;
            _saleMasterRepository = saleMasterRepository;
            _saleDetailsRepository = saleDetailsRepository;
            _userInfoRepository = userInfoRepository;
        }
        public IProductRepository ProductRepository => _productRepository??new ProductRepository(_context);

        public ICustomerInfoRepository CustomerInfoRepository => _customerInfoRepository??new CustomerInfoRepository(_context);

        public ISaleMasterRepository SaleMasterRepository => _saleMasterRepository??new SaleMasterRepository(_context);

        public ISaleDetailsRepository SaleDetailsRepository => _saleDetailsRepository??new SaleDetailsRepository(_context);

        public IUserInfoRepository UserInfoRepository => _userInfoRepository??new UserInfoRepository(_context);

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

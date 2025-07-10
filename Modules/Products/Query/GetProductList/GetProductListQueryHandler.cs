using Inventory.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Inventory.Modules.Products.Query.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductListResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<ProductListResponse>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var getAll = await _unitOfWork.ProductRepository.ListAllAsync();
                var result = (from p in getAll
                              select new ProductListResponse
                              {
                                  ProductId = p.ProductId,
                                  ProductName = p.ProductName,
                                  Barcode = p.Barcode,
                                  Price = p.Price,
                                  StockQty = p.StockQty,
                                  Category = p.Category,
                                  Status = p.Status == true ? "Active" : "Inactive"

                              }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                return new List<ProductListResponse>();
            }
        }
    }
}

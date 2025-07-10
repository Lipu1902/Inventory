using Inventory.Modules.Products.Query.GetProductList;
using Inventory.Persistence;
using MediatR;

namespace Inventory.Modules.Products.Query.GetProductListByBadcode
{
    public class GetProductListByBadcodeQueryHandler : IRequestHandler<GetProductListByBadcodeQuery, List<ProductListByBadcodeResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductListByBadcodeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<ProductListByBadcodeResponse>> Handle(GetProductListByBadcodeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var getAll = (await _unitOfWork.ProductRepository.ListAllAsync()).Where(p => p.Barcode == request.Barcode);
                var result = (from p in getAll
                              select new ProductListByBadcodeResponse
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
                return new List<ProductListByBadcodeResponse>();
            }
        }
    }
}

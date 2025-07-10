using Inventory.Entities;
using Inventory.Persistence;
using MediatR;

namespace Inventory.Modules.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var checkProduct = (await _unitOfWork.ProductRepository.ListAllAsync()).Where(p => p.Barcode == request.Barcode).ToList();
                if (checkProduct.Count() > 0)
                {
                    return  0;
                }
                else
                {
                    var createRequest = new Product()
                    {
                        ProductName = request.ProductName,
                        Barcode = request.Barcode,
                        Price = request.Price,
                        StockQty = request.StockQty,
                        Category = request.Category,
                        Status = request.Status,
                    };
                    var response = await _unitOfWork.ProductRepository.AddAsync(createRequest);
                    await _unitOfWork.Save();
                    return response.ProductId;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}

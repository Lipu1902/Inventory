using Inventory.Persistence;
using MediatR;

namespace Inventory.Modules.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var updateCommnad = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductId);
                if (updateCommnad == null)
                {
                    return ("Product not found");
                }
                updateCommnad.ProductId = request.ProductId;
                updateCommnad.ProductName = request.ProductName;
                updateCommnad.Barcode = request.Barcode;
                updateCommnad.Price = request.Price;
                updateCommnad.StockQty = request.StockQty;
                updateCommnad.Category = request.Category;
                updateCommnad.Status = request.Status;
                await _unitOfWork.ProductRepository.UpdateAsync(updateCommnad);

                var response = await _unitOfWork.Save();
                if(response>0)
                {
                    return ("Product update Successfully");
                }
                else
                {
                    return ("Could not update");
                }
            }
            catch (Exception ex)
            {
                return ("Could not update");
            }
        }
    }
}

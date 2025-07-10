using Inventory.Persistence;
using MediatR;

namespace Inventory.Modules.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var deleteCommnad = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductId);
                if (deleteCommnad == null)
                {
                    return ("Product not found");
                }
                deleteCommnad.IsDelete = true;
                await _unitOfWork.ProductRepository.UpdateAsync(deleteCommnad);

                var response = await _unitOfWork.Save();
                if (response > 0)
                {
                    return ("Product delete Successfully");
                }
                else
                {
                    return ("Could not delete");
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}

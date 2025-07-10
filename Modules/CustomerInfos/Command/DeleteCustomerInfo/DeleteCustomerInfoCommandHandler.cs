using Inventory.Persistence;
using MediatR;

namespace Inventory.Modules.CustomerInfos.Command.DeleteCustomerInfo
{
    public class DeleteCustomerInfoCommandHandler : IRequestHandler<DeleteCustomerInfoCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCustomerInfoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> Handle(DeleteCustomerInfoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var updateCommnad = await _unitOfWork.CustomerInfoRepository.GetByIdAsync(request.CustomerId);
                if (updateCommnad == null)
                {
                    return ("Customer not found");
                }
                updateCommnad.IsDelete = true;
                await _unitOfWork.CustomerInfoRepository.UpdateAsync(updateCommnad);
                var response = await _unitOfWork.Save();
                if (response > 0)
                {
                    return ("Customer delete Successfully");
                }
                else
                {
                    return ("Could not delete Customer");
                }
            }
            catch (Exception ex)
            {
                return ("Could not delete customer");
            }
        }
    }
}

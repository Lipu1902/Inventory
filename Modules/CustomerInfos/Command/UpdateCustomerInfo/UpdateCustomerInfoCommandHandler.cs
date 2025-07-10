using Azure;
using Inventory.Persistence;
using MediatR;

namespace Inventory.Modules.CustomerInfos.Command.UpdateCustomerInfo
{
    public class UpdateCustomerInfoCommandHandler : IRequestHandler<UpdateCustomerInfoCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCustomerInfoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> Handle(UpdateCustomerInfoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var updateCommnad = await _unitOfWork.CustomerInfoRepository.GetByIdAsync(request.CustomerId);
                if (updateCommnad == null)
                {
                    return ("Customer not found");
                }
                updateCommnad.FullName = request.FullName;
                updateCommnad.Email = request.Email;
                updateCommnad.Phone = request.Phone;
                updateCommnad.LoyaltyPoints = request.LoyaltyPoints;
                updateCommnad.IsDelete= request.IsDelete;
                await _unitOfWork.CustomerInfoRepository.UpdateAsync(updateCommnad);
                var response = await _unitOfWork.Save();
                if (response > 0)
                {
                    return ("Customer update Successfully");
                }
                else
                {
                    return ("Could not update Customer");
                }
            }
            catch (Exception ex)
            {
                return ("Could not update customer");
            }
        }
    }
}

using Inventory.Entities;
using Inventory.Persistence;
using MediatR;

namespace Inventory.Modules.CustomerInfos.Command.CreateCustomerInfo
{
    public class CreateCustomerInfoCommandHandler : IRequestHandler<CreateCustomerInfoCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateCustomerInfoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> Handle(CreateCustomerInfoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var createCommand = new CustomerInfo()
                {
                    FullName = request.FullName,
                    Email = request.Email,
                    Phone= request.Phone,
                    LoyaltyPoints = request.LoyaltyPoints,
                };
                await _unitOfWork.CustomerInfoRepository.AddAsync(createCommand);
                var response = await _unitOfWork.Save();
                if(response>0)
                {
                    return ("Customer add Successfully");
                }
                else
                {
                    return ("Could not add customer");
                }
            }
            catch (Exception ex)
            {
                return ("Could not add customer");
            }
        }
    }
}

using Inventory.Persistence;
using MediatR;

namespace Inventory.Modules.CustomerInfos.Query.GetCustomerInfoList
{
    public class GetCustomerInfoListQuesryHandler : IRequestHandler<GetCustomerInfoListQuesry, List<CustomerInfoListResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCustomerInfoListQuesryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<CustomerInfoListResponse>> Handle(GetCustomerInfoListQuesry request, CancellationToken cancellationToken)
        {
            try
            {
                var allCustomer = await _unitOfWork.CustomerInfoRepository.ListAllAsync();

                var result=(from c in allCustomer
                            select new CustomerInfoListResponse
                            {
                                CustomerId = c.CustomerId,
                                FullName = c.FullName,
                                Email = c.Email,
                                Phone = c.Phone,
                                LoyaltyPoints = c.LoyaltyPoints,
                                IsDelete = c.IsDelete,

                            }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                return new List<CustomerInfoListResponse>();
            }
        }
    }
}

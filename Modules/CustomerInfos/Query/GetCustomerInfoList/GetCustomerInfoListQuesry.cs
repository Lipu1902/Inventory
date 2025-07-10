using MediatR;

namespace Inventory.Modules.CustomerInfos.Query.GetCustomerInfoList
{
    public class GetCustomerInfoListQuesry:IRequest<List<CustomerInfoListResponse>>
    {
    }
}

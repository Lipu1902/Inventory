using MediatR;

namespace Inventory.Modules.CustomerInfos.Command.DeleteCustomerInfo
{
    public class DeleteCustomerInfoCommand:IRequest<string>
    {
        public int CustomerId { get; set; }
        public Boolean IsDelete { get; set; }
    }
}

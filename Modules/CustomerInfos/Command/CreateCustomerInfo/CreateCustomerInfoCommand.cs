using MediatR;

namespace Inventory.Modules.CustomerInfos.Command.CreateCustomerInfo
{
    public class CreateCustomerInfoCommand:IRequest<string>
    {
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int LoyaltyPoints { get; set; }
    }
}

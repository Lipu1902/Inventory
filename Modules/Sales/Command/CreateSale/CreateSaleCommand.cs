using Inventory.Modules.SalesDetails.Command.CreateSalesDetails;
using MediatR;

namespace Inventory.Modules.Sales.Command.CreateSale
{
    public class CreateSaleCommand:IRequest<string>
    {
        //public DateTime SaleDate { get; set; }
        public int CustomerId { get; set; }
        public Decimal TotalAmount { get; set; }
        public Decimal PaidAmount { get; set; }
        public Decimal DueAmount { get; set; }
        public List<CreateSalesDetailsCommand> createSalesDetailsCommands { get; set; }
    }
}

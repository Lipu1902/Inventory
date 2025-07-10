namespace Inventory.Modules.SalesDetails.Command.CreateSalesDetails
{
    public class CreateSalesDetailsCommand
    {
        //public int SaleMasterId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}

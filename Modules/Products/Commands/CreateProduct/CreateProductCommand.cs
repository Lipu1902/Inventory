using MediatR;

namespace Inventory.Modules.Products.Commands.CreateProduct
{
    public class CreateProductCommand:IRequest<int>
    {
        public string ProductName { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal StockQty { get; set; }
        public string Category { get; set; } = string.Empty;
        public bool Status { get; set; }
    }
}

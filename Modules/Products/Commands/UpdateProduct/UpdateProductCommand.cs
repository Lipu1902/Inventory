using MediatR;

namespace Inventory.Modules.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand:IRequest<string>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal StockQty { get; set; }
        public string Category { get; set; } = string.Empty;
        public Boolean Status { get; set; }
    }
}


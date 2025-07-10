namespace Inventory.Modules.Products.Query.GetProductList
{
    public class ProductListResponse
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal StockQty { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

    }
}

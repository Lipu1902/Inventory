using System.ComponentModel.DataAnnotations;

namespace Inventory.Entities
{
    public class SaleDetails
    {
        [Key]
        public int Id { get; set; }
        public int SaleMasterId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}

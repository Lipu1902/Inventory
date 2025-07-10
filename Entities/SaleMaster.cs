using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Entities
{
    public class SaleMaster
    {
        [Key]
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }        
        public int CustomerId { get; set; }
        public Decimal TotalAmount { get; set; }
        public Decimal PaidAmount { get; set; }
        public Decimal DueAmount { get; set; }
    }
}

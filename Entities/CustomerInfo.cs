using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Entities
{
    public class CustomerInfo
    {
        [Key]
        public int CustomerId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int LoyaltyPoints { get; set; }
        public Boolean IsDelete { get; set; }
    }
}

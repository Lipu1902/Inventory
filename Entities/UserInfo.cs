using System.ComponentModel.DataAnnotations;

namespace Inventory.Entities
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Thelegend107.Data.Lib.Entities
{
    [Table("Customer")]
    public partial record Customer
    {
        public int Id { get; set; }
        public string? Company { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string Password { get; set; } = null!;
        public bool IsAdmin { get; set; } = false;
    }
}

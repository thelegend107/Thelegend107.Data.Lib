using System.ComponentModel.DataAnnotations.Schema;

namespace Thelegend107.Data.Lib.Entities
{
    [Table("Address")]
    public partial record Address
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string Address1 { get; set; } = null!;
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public virtual State? State { get; set; }
        public virtual Country? Country { get; set; }
    }
}
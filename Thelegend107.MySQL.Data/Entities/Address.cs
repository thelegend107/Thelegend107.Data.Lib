using MapDataReader;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiV2.Entities
{
    [GenerateDataReaderMapper]
    [Table("Address")]
    public partial class Address
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string Address1 { get; set; } = null!;
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public virtual State? State { get; set; }
        public virtual Country? Country { get; set; }
    }
}
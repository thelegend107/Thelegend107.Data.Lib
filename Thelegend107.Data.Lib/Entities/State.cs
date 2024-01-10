using System.ComponentModel.DataAnnotations.Schema;

namespace Thelegend107.Data.Lib.Entities
{
    [Table("State")]
    public partial record State
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string StateCode { get; set; } = null!;
        public string Name { get; set; } = null!;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
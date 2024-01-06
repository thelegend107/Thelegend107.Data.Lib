using MapDataReader;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiV2.Entities
{
    [GenerateDataReaderMapper]
    [Table("SubRegion")]
    public partial class SubRegion
    {
        public int Id { get; set; }
        public int? RegionId { get; set; }
        public string Name { get; set; } = null!;
    }
}
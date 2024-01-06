using MapDataReader;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiV2.Entities
{
    [GenerateDataReaderMapper]
    [Table("Region")]
    public partial class Region
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
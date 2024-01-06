using MapDataReader;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResumeAPI.Entities
{
    [GenerateDataReaderMapper]
    [Table("[dbo].[SubRegion]")]
    public partial class SubRegion
    {
        public int Id { get; set; }
        public int? RegionId { get; set; }
        public string Name { get; set; } = null!;
    }
}
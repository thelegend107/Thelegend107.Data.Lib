using MapDataReader;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thelegend107.SQL.Data.Lib.Entities
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
using MapDataReader;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thelegend107.SQL.Data.Lib.Entities
{
    [GenerateDataReaderMapper]
    [Table("[dbo].[Region]")]
    public partial class Region
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
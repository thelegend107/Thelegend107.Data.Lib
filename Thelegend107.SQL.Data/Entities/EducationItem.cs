using MapDataReader;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thelegend107.SQL.Data.Lib.Entities
{
    [GenerateDataReaderMapper]
    [Table("[dbo].[EducationItem]")]
    public partial class EducationItem
    {
        public int Id { get; set; }
        public int EducationId { get; set; }
        public string Name { get; set; } = null!;
    }
}
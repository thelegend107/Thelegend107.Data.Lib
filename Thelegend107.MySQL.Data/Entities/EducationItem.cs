using MapDataReader;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiV2.Entities
{
    [GenerateDataReaderMapper]
    [Table("EducationItem")]
    public partial class EducationItem
    {
        public int Id { get; set; }
        public int EducationId { get; set; }
        public string Name { get; set; } = null!;
    }
}
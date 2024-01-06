using MapDataReader;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiV2.Entities
{
    [GenerateDataReaderMapper]
    [Table("WorkExperienceItem")]
    public partial class WorkExperienceItem
    {
        public int Id { get; set; }
        public int WorkExperienceId { get; set; }
        public string Description { get; set; } = null!;
    }
}
using MapDataReader;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResumeAPI.Entities
{
    [GenerateDataReaderMapper]
    [Table("[dbo].[WorkExperienceItem]")]
    public partial class WorkExperienceItem
    {
        public int Id { get; set; }
        public int WorkExperienceId { get; set; }
        public string Description { get; set; } = null!;
    }
}
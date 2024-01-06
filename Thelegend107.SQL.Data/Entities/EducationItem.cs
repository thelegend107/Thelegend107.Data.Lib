using MapDataReader;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResumeAPI.Entities
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
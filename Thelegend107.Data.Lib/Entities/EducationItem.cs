using System.ComponentModel.DataAnnotations.Schema;

namespace Thelegend107.Data.Lib.Entities
{
    [Table("EducationItem")]
    public partial record EducationItem
    {
        public int Id { get; set; }
        public int EducationId { get; set; }
        public string Name { get; set; } = null!;
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace Thelegend107.Data.Lib.Entities
{
    [Table("Skill")]
    public partial record Skill
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
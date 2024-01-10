using System.ComponentModel.DataAnnotations.Schema;

namespace Thelegend107.Data.Lib.Entities
{
    [Table("Education")]
    public partial record Education
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? AddressId { get; set; }
        public string School { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Grade { get; set; }

        public virtual Address? Address { get; set; }
        public virtual ICollection<EducationItem> EducationItems { get; set; } = new List<EducationItem>();
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace Thelegend107.Data.Lib.Entities
{
    [Table("WorkExperience")]
    public partial record WorkExperience
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? AddressId { get; set; }
        public string Employer { get; set; } = null!;
        public string Title { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? PayRate { get; set; }

        public virtual Address? Address { get; set; }
        public virtual ICollection<WorkExperienceItem> WorkExperienceItems { get; set; } = new List<WorkExperienceItem>();
    }
}
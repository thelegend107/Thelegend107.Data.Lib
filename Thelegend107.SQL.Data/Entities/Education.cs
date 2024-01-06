using MapDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResumeAPI.Entities
{
    [GenerateDataReaderMapper]
    [Table("[dbo].[Education]")]
    public partial class Education
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? AddressId { get; set; }
        public string School { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Grade { get; set; }

        public virtual Address? Address { get; set; }
        public virtual IEnumerable<EducationItem> EducationItems { get; set; } = new List<EducationItem>();
    }
}
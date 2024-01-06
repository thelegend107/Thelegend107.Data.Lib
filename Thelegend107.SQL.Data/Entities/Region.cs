using MapDataReader;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResumeAPI.Entities
{
    [GenerateDataReaderMapper]
    [Table("[dbo].[Region]")]
    public partial class Region
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
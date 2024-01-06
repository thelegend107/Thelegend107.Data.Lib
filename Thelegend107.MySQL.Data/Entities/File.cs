using MapDataReader;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiV2.Entities
{
    [GenerateDataReaderMapper]
    [Table("File")]
    public partial class File
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Data { get; set; } = null!;
    }
}
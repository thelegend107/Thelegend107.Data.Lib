using MapDataReader;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thelegend107.SQL.Data.Lib.Entities
{
    [GenerateDataReaderMapper]
    [Table("[dbo].[Skill]")]
    public partial class Skill
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
using MapDataReader;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thelegend107.SQL.Data.Lib.Entities
{
    [GenerateDataReaderMapper]
    [Table("[dbo].[Link]")]
    public partial class Link
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string URL { get; set; } = null!;
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace Thelegend107.MySQL.Data.Lib.Entities
{
    [Table("SubRegion")]
    public partial class SubRegion
    {
        public int Id { get; set; }
        public int? RegionId { get; set; }
        public string Name { get; set; } = null!;
    }
}
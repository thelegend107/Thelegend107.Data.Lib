using System.ComponentModel.DataAnnotations.Schema;

namespace Thelegend107.MySQL.Data.Lib.Entities
{
    [Table("Region")]
    public partial class Region
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
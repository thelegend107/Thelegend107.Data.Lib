using System.ComponentModel.DataAnnotations.Schema;

namespace Thelegend107.Data.Lib.Entities
{
    [Table("Region")]
    public partial record Region
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
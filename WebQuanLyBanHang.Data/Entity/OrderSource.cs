using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyBanHang.Data.Entity
{
    [Table("OrderSources")]
    public class OrderSource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; } = string.Empty;
        public bool IsCheck { get; set; } = false; /// Tích mặc định hay không mặc định
    }
}
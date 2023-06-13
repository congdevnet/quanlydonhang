using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyBanHang.Data.Entity
{
    /// <summary>
    /// Table Hình thức  giao hàng
    /// </summary>
    [Table("MethodDeliverys")]
    public class MethodDelivery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; } = string.Empty;
    }
}
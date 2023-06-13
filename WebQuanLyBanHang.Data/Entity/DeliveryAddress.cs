using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyBanHang.Data.Entity
{
    /// <summary>
    /// Địa chỉ lấy hàng
    /// </summary>
    [Table("DeliveryAddress")]
    public class DeliveryAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int City { get; set; } /// Tỉnh thành/Thành Phố
        [Required]
        public int District { get; set; } /// Quận/Huyện
        [Required]
        public int Wards { get; set; } // Xã/Phường
        [Required]
        [StringLength(256)]
        public string Address { get; set; } = string.Empty; /// Địa chỉ chi tiết
        public bool IsDefault { get; set; } = false;/// Đặt mặc định hay không?
    }
}
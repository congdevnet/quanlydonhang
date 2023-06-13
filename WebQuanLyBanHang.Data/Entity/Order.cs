using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyBanHang.Data.Entity
{
    /// <summary>
    ///  Tạo đơn hàng
    /// </summary>
    [Table("Orders")]
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime? DateCreated { get; set; }// ngày nhập đơn

        public Guid UserId { get; set; }    
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
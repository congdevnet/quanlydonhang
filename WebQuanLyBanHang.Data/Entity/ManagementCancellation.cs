using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyBanHang.Data.Entity
{
    [Table("ManagementCancellations")]
    public class ManagementCancellation
    {
        [Key]
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }
        public DateTime? DeleteDate { get; set; } // Ngày hủy đơn

        [MaxLength(500)]
        public string? Note { get; set; } = string.Empty; /// Lý Do Hủy / xem xét lại

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
    }
}
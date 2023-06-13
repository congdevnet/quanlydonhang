using System.ComponentModel.DataAnnotations;

namespace WebQuanLyBanHang.Utilities.ViewModel
{
    public class ManagementCancellationsVM
    {
        public Guid OrderId { get; set; }
        public DateTime? DeleteDate { get; set; } // Ngày hủy đơn

        [MaxLength(500)]
        public string? Note { get; set; } = string.Empty; /// Lý Do Hủy / xem xét lại
    }
}
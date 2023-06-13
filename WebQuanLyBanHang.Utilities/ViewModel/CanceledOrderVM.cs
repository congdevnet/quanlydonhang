using System.Globalization;

namespace WebQuanLyBanHang.Utilities.ViewModel
{
    public class CanceledOrderVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public DateTime? DeleteDate { get; set; } = DateTime.Now;
        public string Note { get; set; } = string.Empty;
    }
}
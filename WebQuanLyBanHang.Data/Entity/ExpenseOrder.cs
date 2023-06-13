using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyBanHang.Data.Entity
{
    /// <summary>
    ///  Chi phí đơn hàng
    /// </summary>
    [Table("ExpenseOrders")]
    public class ExpenseOrder // Table chi phí đơn hàng //
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Guid OrderId { get; set; }
        public double IntoMoney { get; set; } /// Thành tiến
        public double Discount { get; set; } /// Giảm giá
        public double TransportFee { get; set; } /// Phí vận chuyển
        public double Surcharge { get; set; } /// Phụ thu
        public double DeclarePrice { get; set; } // Khai giá
        public double Prepay { get; set; }// Trả trước
        public double Payments { get; set; } // Còn phải trả
        public double StillOwed { get; set; }   /// Còn nợ

        [ForeignKey(nameof(OrderId))]
        public Order? Orders { get; set; }
    }
}
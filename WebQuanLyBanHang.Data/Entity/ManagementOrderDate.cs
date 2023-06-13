using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyBanHang.Data.Entity
{
    [Table("ManagementOrderDates")]
    public class ManagementOrderDate
    {
        [Key]
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }
        public DateTime? ClosingDate { get; set; } // Ngày chốt đơn
        public DateTime? DayShipping { get; set; }// Ngày vận đơn
        public DateTime? FinishDay { get; set; } //Ngày hoàn thành
        public DateTime? ConfirmationDate { get; set; } // ngày xác nhận đơn

        [ForeignKey("OrderId")]
        public Order? Order { get; set; }
    }
}
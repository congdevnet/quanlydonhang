namespace WebQuanLyBanHang.Data.Entity
{
    public class ManagementOrderDatesVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid OrderId { get; set; }
        public DateTime? ClosingDate { get; set; } // Ngày chốt đơn
        public DateTime? DayShipping { get; set; }// Ngày vận đơn
        public DateTime? FinishDay { get; set; } //Ngày hoàn thành
        public DateTime? ConfirmationDate { get; set; } // ngày xác nhận đơn
        public ManagementOrderDatesVM(Guid OrderId, DateTime? ClosingDate)
        {
            this.OrderId = OrderId;
            this.ClosingDate = ClosingDate;
        }
    }
}
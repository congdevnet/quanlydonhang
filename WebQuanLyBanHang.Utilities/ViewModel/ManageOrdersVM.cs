namespace WebQuanLyBanHang.Utilities.ViewModel
{
    public class ManageOrdersVM
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public bool IsOrderActive { get; set; } // kiểm tra xem khách được lên đơn chưa.
        public ManageOrdersVM(Guid orderId, Guid customerId, DateTime? applicationDate, bool isOrderActive)
        {
            OrderId = orderId;
            CustomerId = customerId;
            ApplicationDate = applicationDate;
            IsOrderActive= isOrderActive;

        }
    }
}
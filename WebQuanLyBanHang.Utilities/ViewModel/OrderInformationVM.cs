namespace WebQuanLyBanHang.Utilities.ViewModel
{
    public class OrderInformationVM
    {
       
        public Guid OrderId { get; set; } = Guid.NewGuid();
        public DateTime? DateAdded { get; set; } = DateTime.Now;
        public Guid? UserCreId { get; set; }
        public bool IsOrderActive { get; set; } = false;
        /// <summary>
        /// Khu vực khách hàng
        /// </summary>
        public CustomerOrder CustomerOrder { get; set; } = new CustomerOrder();

        public ExpenseOrderVM? ExpenseOrderVM { get; set; }
        public ManagementOrderVM? ManagementOrderVM { get; set; }
        ///Danh sách sản phẩm //
        public List<CartItem>? CartItems { get; set; } = new List<CartItem>();
    }
}
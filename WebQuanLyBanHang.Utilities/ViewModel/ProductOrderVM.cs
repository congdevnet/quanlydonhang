namespace WebQuanLyBanHang.Utilities.ViewModel
{
    public class ProductOrderVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public double Quantity { get; set; }
    }
}
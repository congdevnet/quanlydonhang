namespace WebQuanLyBanHang.Utilities.ViewModel
{
    public class CartItem
    {
        public Guid OrderDetailsId { get; set; }
        public Guid CartId { get; set; } = Guid.NewGuid();
        public int Quantity { set; get; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public double Price { get; set; } = double.NaN;
        public double UnitPrice { get; set; } = double.NaN;
    }
}
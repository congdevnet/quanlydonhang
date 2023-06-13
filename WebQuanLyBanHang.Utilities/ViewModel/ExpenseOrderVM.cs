namespace WebQuanLyBanHang.Utilities.ViewModel
{
    public class ExpenseOrderVM
    {
        //public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public double IntoMoney { get; set; } /// Thành tiến
        public double Discount { get; set; } /// Giảm giá
        public double TransportFee { get; set; } /// Phí vận chuyển
        public double Surcharge { get; set; } /// Phụ thu
        public double DeclarePrice { get; set; } // Khai giá
        public double Prepay { get; set; }// Trả trước
        public double StillOwed { get; set; }   /// Còn nợ
        public double Payments { get; set; } // Còn phải trả
    }
}
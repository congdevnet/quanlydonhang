namespace WebQuanLyBanHang.Utilities
{
    public static class ConstPrameter
    {
        public static Guid Guiddefault = Guid.Parse("00000000-0000-0000-0000-000000000000");
        public static int OrderStatusOrderId = 3;/// Trạng thái đặt hàng.
        public static int Order = 4; // Trạng thái đặt hàng
        public static int OrderStatuslatchOrderId = 5;/// Trạng thái chốt đơn hàng.
        public static int Appointment = 8; // khách hàng hẹn;
        public static int OrderConfirm = 4;
        public static int OrderTransport = 6;
        public static int OrderSuccessful = 7;
        public static int CustomerStatusBom = 10;
        public static Guid OrderId = Guid.Parse("00000000-0000-0000-0000-000000000000");
        public static string PawordDefult = "thaiduonghoc@gmail";
        public static string Receive = "Mới nhập";
    }
}
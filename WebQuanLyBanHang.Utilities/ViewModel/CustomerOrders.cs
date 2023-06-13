using WebQuanLyBanHang.Common;

namespace WebQuanLyBanHang.Utilities.ViewModel
{
    public class CustomerOrders
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public string CusName { get; set; } = string.Empty;
        public Guid CusId { get; set; }
        public string CusAddress { get; set; } = string.Empty;
        public string CusEmail { get; set; } = string.Empty;
        public string CusPhoneNumber { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public Gender CusGender { get; set; } = Gender.Male;
        public double? CusAge { get; set; } = double.NaN;
        public double? CusWeight { get; set; } = double.NaN;
        public bool IsOrderActive { get; set; } = false;
    }
}


using System.ComponentModel.DataAnnotations;

namespace WebQuanLyBanHang.Utilities.ViewModel
{
    public class CustomerMKTVM
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        [Required(ErrorMessage ="Nhập số điện thoại!")]
        [StringLength(12,ErrorMessage ="Nhập đủ 12 ký tự")]
        [MinLength(10, ErrorMessage = "Nhập đủ 10 ký tự")]
        public string PhoneNumber { get; set; }
        public string? LinkFacebook { get; set; }
        public double? Age { get; set; }
        public double? Weight { get; set; }

        public Guid? UserId { get; set; }
    }
}

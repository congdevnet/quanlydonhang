using System.ComponentModel.DataAnnotations;
using WebQuanLyBanHang.Common;

namespace WebQuanLyBanHang.Utilities.ViewModel
{
    public class CustomerOrder
    {
        public Guid CusId { get; set; }

        [Display(Name = "Họ và tên")]
        [MaxLength(256, ErrorMessage = "Nhập quá 256 ký tự")]
        [Required(ErrorMessage = "Không được bỏ trống trường này!")]
        public string CusName { get; set; } = string.Empty;

        [Display(Name = "Địa chỉ nhà")]
        [MaxLength(256, ErrorMessage = "Nhập quá 256 ký tự")]
        [Required(ErrorMessage = "Không được bỏ trống trường này!")]
        public string CusAddress { get; set; } = string.Empty;

        [Display(Name = "Email liên hệ")]
        [MaxLength(256, ErrorMessage = "Nhập quá 256 ký tự")]
        [Required(ErrorMessage = "Không được bỏ trống trường này!")]
        [EmailAddress(ErrorMessage = "Không đúng định dạng email!")]
        public string CusEmail { get; set; } = string.Empty;

        public string CusPhoneNumber { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public Gender CusGender { get; set; } = Gender.Male;
        public string? LinkFacebook { get; set; } = string.Empty;

        public double? CusAge { get; set; } = double.NaN;
        public double? CusWeight { get; set; } = double.NaN;

        [Required(ErrorMessage = "Không được bỏ trống trường này!")]
        public int CusCity { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống trường này!")]
        public int CusDistrict { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống trường này!")]
        public int Cusward { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống trường này!")]
        public int CusGrpCusId { get; set; }
    }
}
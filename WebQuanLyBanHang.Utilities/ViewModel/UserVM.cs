using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebQuanLyBanHang.Utilities.ViewModel
{
    public class UserVM
    {
        public Guid Id {  get; set; }
        [Required(ErrorMessage ="Không được bỏ trồng!")]
        [MaxLength(256,ErrorMessage ="Vượt quá 256 ký tự!")]
        public string FullName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Không được bỏ trồng!")]
        [MaxLength(256, ErrorMessage = "Vượt quá 256 ký tự!")]
        public  string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Không được bỏ trồng!")]
        [MaxLength(256, ErrorMessage = "Vượt quá 256 ký tự!")]
        public string PasswordHash { get; set; } = ConstPrameter.PawordDefult;
        [Required(ErrorMessage = "Không được bỏ trồng!")]
        [MaxLength(256, ErrorMessage = "Vượt quá 256 ký tự!")]
        public  string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Không được bỏ trồng!")]
        [MaxLength(256, ErrorMessage = "Vượt quá 256 ký tự!")]
        public  string PhoneNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "Chưa chọn giới tính!")]
        [DisplayName("Giới tính")]
        public bool Sex { get; set; }
        public DateTime? DateOfBirth { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Không được bỏ trồng!")]
        [MaxLength(256, ErrorMessage = "Vượt quá 256 ký tự!")]
        public string Address { get; set; } = string.Empty;
        public int? CityId { get; set; } = 1;
        public string? Skype { get; set; } = "Skype";
        public string? Avartar { get; set; } = "Avartar";
        public DateTime? DateCreated { get; set; }
        public string? RoleName { get; set;} = string.Empty;
        [Required(ErrorMessage = "Chưa chọn quyền truy cập!")]
        public Guid RoleId { get; set; }
    }
}
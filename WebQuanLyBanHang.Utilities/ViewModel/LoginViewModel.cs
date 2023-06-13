using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQuanLyBanHang.Utilities.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Tên đăng nhập không được bỏ trống?.")]
        [MaxLength(256)]
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mật khẩu không được bỏ trống?.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        [MaxLength(256)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Lưu thông tin tài khoản?")]
        public bool RememberMe { get; set; }
    }
}

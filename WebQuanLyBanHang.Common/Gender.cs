
using System.ComponentModel.DataAnnotations;

namespace WebQuanLyBanHang.Common
{
    public enum Gender
    {
        [Display(Name ="Nam")]
        Male,
        [Display(Name = "Nữ")]
        Female,
        [Display(Name = "Không xác định")]
        Gay
    }
}

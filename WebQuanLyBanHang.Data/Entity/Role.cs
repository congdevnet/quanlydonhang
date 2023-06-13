using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;


namespace WebQuanLyBanHang.Data.Entity
{
    public class Role: IdentityRole<Guid>
    {
        public string Description { get; set; } = string.Empty;
    }
}

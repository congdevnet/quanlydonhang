using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyBanHang.Data.Entity
{
    public class User: IdentityUser<Guid>
    {
       
        public string FullName { get; set; } = string.Empty;

        public bool Sex { get; set; }
        public DateTime? DateOfBirth { get; set; } = DateTime.Now;
        public string Address { get; set; } = string.Empty;
        public int CityId { get; set; }
        public string Skype { get; set; } = string.Empty;
        public string Avartar { get; set; } = string.Empty;
        public DateTime? DateCreated { get; set; }
    }
}

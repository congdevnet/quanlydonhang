using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyBanHang.Common;

namespace WebQuanLyBanHang.Utilities.ViewModel
{
    public class CustomerVM
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public Gender Gender { get; set; } = Gender.Male;
        public string LinkFacebook { get; set; } = string.Empty;
        public double Age { get; set; } = double.NaN;
        public double Weight { get; set; } = double.NaN;
        public int City { get; set; }
        public int? District { get; set; }
        public int? ward { get; set; }
        public int GrpCusId { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}

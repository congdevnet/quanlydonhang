using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQuanLyBanHang.Utilities.ViewModel
{
    public class OrderStatusVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Orders { get; set; }
        public string Color { get; set; } = string.Empty;
    }
}

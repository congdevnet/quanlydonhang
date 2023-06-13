using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQuanLyBanHang.Utilities.ViewModel
{
    public class OrderSourceVM
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public bool IsCheck { get; set; } = false;
    }
}

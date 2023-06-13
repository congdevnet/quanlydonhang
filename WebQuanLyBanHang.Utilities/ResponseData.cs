using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQuanLyBanHang.Utilities
{
    public class ResponseData<T>
    {
        public int TotalPage { get; set; }
        public int PageIndex { get; set; } = 1;
        public List<T> Items { get; set; } = new List<T>();
    }
}

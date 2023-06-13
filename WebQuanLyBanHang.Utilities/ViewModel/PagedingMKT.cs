using System;
using System.Collections.Generic;
using System.Linq;


namespace WebQuanLyBanHang.Utilities.ViewModel
{
    public class PagedingMKT: Pageding
    {
        public Guid UserId { get; set; }
        public string? Role { get; set; }
    }
}



namespace WebQuanLyBanHang.Utilities
{
    public class Pageding
    {
        public string KeyWord { get; set; } = string.Empty;
        public int PageSize { get; set; } = 8;
        public int PageNum { get; set; } = 1;
        public DateTime? StartDay { get; set; }
        public DateTime? EndDay { get; set;}
        public int? StatusCustomer { get; set; } = 0;
        public int? OrderStatus { get; set; } = 0;
        // public int TotalPages { get; set; }

    }
}

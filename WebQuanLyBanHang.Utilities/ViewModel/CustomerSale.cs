namespace WebQuanLyBanHang.Utilities.ViewModel
{
    public class CustomerSale
    {
        public Guid Id { get; set; }
        public string NameCus { get; set; } = string.Empty;
        public string EmailCus { get; set; }= string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string NameMKT { get; set; } = string.Empty;
        public string NameSale { get; set; } = string.Empty;
        public string StatusSale { get; set; } = string.Empty;
        public int Status { get; set; } = 0;
        public DateTime? CretedDate { get; set; }
        public DateTime? DateBom { get; set; }
        public string Note { get; set; }
        public bool IsOrderActive { get; set; }
        public bool IsActive { get; set; }
        public bool IsSale { get; set; }
    }
}
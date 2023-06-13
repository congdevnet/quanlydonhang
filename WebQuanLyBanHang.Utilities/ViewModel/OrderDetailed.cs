namespace WebQuanLyBanHang.Utilities.ViewModel
{
	public class OrderDetailed
	{
		public Guid OrderId { get; set; }
		public Guid CustomerId { get; set; }
		public string CustomerName { get; set; } = string.Empty;
		public string CustomerPhone { get; set; } = string.Empty;
		public string CustomerEmail { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public string City { get; set; } = string.Empty;
		public int? CityId { get; set; }

		public string District { get; set; } = string.Empty;
		public int? DistrictId { get; set; }

        public string Ward { get; set; } = string.Empty;
		public int? WardId { get; set; }

        public DateTime? OrderDate { get; set; }
		public int? OderStatusId { get; set; }

        public string OrderStatus { get; set; } = string.Empty;
        public DateTime? DateShip { get; set; }
    }
}
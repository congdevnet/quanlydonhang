using System.ComponentModel.DataAnnotations;

namespace WebQuanLyBanHang.Utilities.ViewModel
{
	public class GroupCustomerVM
	{
		public int Id { get; set; }
		[Required]
		[StringLength(256)]
		public string Name { get; set; } = string.Empty;
	}
}
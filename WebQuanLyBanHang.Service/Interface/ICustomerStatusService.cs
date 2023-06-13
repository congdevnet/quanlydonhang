using WebQuanLyBanHang.Data.Entity;

namespace WebQuanLyBanHang.Service.Interface
{
	public interface ICustomerStatusService
	{
		public IEnumerable<CustomerStatus> GetCustomerStatus();
	}
}
using WebQuanLyBanHang.Data.EF;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Repository.Interface;

namespace WebQuanLyBanHang.Repository.Infrastructure
{
	public class CustomerStatusRepsitory : Repository<CustomerStatus>, ICustomerStatusRepsitory
	{
		public CustomerStatusRepsitory(QuanLyBanHangDbContent dbContext) : base(dbContext)
		{
		}
	}
}
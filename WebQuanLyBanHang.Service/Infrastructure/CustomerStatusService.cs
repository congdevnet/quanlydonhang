using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Repository.Interface;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Service.Infrastructure
{
	public class CustomerStatusService : ICustomerStatusService
	{
		private readonly ICustomerStatusRepsitory _customerStatusRepsitory;
        public CustomerStatusService(ICustomerStatusRepsitory customerStatusRepsitory)
        {
			_customerStatusRepsitory = customerStatusRepsitory;
		}
		public IEnumerable<CustomerStatus> GetCustomerStatus()
		{
			List<CustomerStatus> customerStatuses = new List<CustomerStatus>();
			customerStatuses = _customerStatusRepsitory.GetAll().AsEnumerable().ToList();
			return customerStatuses;
		}
	}
}
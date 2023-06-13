using WebQuanLyBanHang.Utilities;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Service.Interface
{
    public interface ICustomerService
    {
        public Task<ResponseData<CustomerSale>> GetAll(Pageding pageding);

        public Task<ResponseData<CustomerSale>> GetAllPhone(PagedingMKT pageding);
        public Task<ResponseData<CustomerSale>> GetOrder(PagedingMKT pageding);
		public Task<ResponseData<CustomerSale>> GetCustomerBom(PagedingMKT pageding);
		public Task Add(CustomerMKTVM customerVM);

        public Task UpdateSale(CustomerMKTVM customerVM);
        public Task EditCustomerStatus(string id , int status);
        public Task Update(CustomerVM customerVM);

        public Task Delete(Guid id);

        public Task<CustomerVM> Get(Guid id);

        public Task<bool> CheckData(string word);

        public Task UpdateSale(Guid saleId, List<string> cusLis);
    }
}
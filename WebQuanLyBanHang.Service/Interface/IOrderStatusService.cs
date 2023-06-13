
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Utilities;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Service.Interface
{
    public interface IOrderStatusService
    {
        public Task<ResponseData<OrderStatusVM>> GetAll(Pageding pageding);
        public Task<List<OrderStatusVM>> Gets();
        public Task Add(OrderStatusVM orderStatus);
        public Task Update(OrderStatusVM orderStatus);
        public Task Delete(int  id);
        public Task<OrderStatusVM> Get(int id);
        public Task<bool> CheckData(string word);
    }
}

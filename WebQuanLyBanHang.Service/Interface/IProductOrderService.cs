using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Service.Interface
{
    public interface IProductOrderService
    {
        public Task Add(ProductOrderVM productOrderVM);
        public Task Delete(Guid id);
    }
}
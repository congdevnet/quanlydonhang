using WebQuanLyBanHang.Utilities;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Service.Interface
{
    public interface IOrderService
    {
        public Task<CustomerOrders> GetCustomerOrders(Guid id);

        public Task<OrderInformationVM> GetOrderInformation(Guid id);

        /// <summary>
        /// Đơn hàng
        /// </summary>
        /// <param name="pageding"></param>
        /// <returns>Danh sách đơn hàng trạng thái đặt hàng</returns>
        public Task<ResponseData<OrderDetailed>> GetOrderOrder(PagedingMKT pageding);

        public Task<OrderInformationVM> GetOrder(Guid id);

        public Task<List<CartItem>> GetCartItem(Guid id);

        public Task Add(OrderVM orderVM, Guid customerId);

        public Task AddCanceledOrder(CanceledOrderVM canceledOrder);

        public Task<bool> GetCheckOrder(Guid id);

        public Task AddOrder(OrderInformationVM orderInformationVM, Guid userId);

        public Task EditOrder(OrderInformationVM orderVM);

        public Task UpdateConfirm(Guid id, int orderstatus);
        public Task Delete(Guid id);
    }
}
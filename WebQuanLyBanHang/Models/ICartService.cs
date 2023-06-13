using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Models
{
    public interface ICartService
    {
        List<CartItem> GetCartItems(ISession session);
        void ClearCart(ISession session);
        void RemoveCart(Guid id, ISession session);
        Task AddCart(Guid productId, int quantity, ISession session);
        
        void SaveCartSession(List<CartItem> ls, ISession session);
    }
}

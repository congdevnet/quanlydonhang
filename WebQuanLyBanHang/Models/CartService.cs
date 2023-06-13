using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System.Globalization;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Models
{
    public class CartService : ICartService
    {
        private readonly IProductService _productService;
        public CartService(IProductService productService)
        {
            _productService = productService;
        }
        public async Task AddCart(Guid productId,int quantity, ISession session)
        {
            var product = await _productService.Get(productId);

            var cart = GetCartItems(session);
            var cartitem = cart.Find(p => p.ProductId == productId);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cartitem.Quantity=quantity;
            }
            else
            {
                //  Thêm mới
                cart.Add(new CartItem() {
                    Quantity = quantity, 
                    CartId= Guid.NewGuid(), 
                    Price= product.Price, 
                    ProductId = product.Id, 
                    ProductName =product.ProductName, 
                    UnitPrice = quantity * product.Price, 
                });
            }

            // Lưu cart vào Session
            SaveCartSession(cart, session);
        }

        public void ClearCart(ISession session)
        {
            session.Remove(ConstSession.CARTKEY);
        }

        public List<CartItem> GetCartItems(ISession session)
        {
            string jsoncart = session.GetString(ConstSession.CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }

        public void RemoveCart(Guid id, ISession session)
        {
            var cart = GetCartItems(session);
            var cartitem = cart.Find(p => p.CartId == id);
            cart.Remove(cartitem);
            SaveCartSession(cart, session);
        }

        public void SaveCartSession(List<CartItem> ls, ISession session)
        {
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(ConstSession.CARTKEY, jsoncart);
        }
    }
}

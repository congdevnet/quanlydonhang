using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyBanHang.Utilities.ViewModel;
using WebQuanLyBanHang.Utilities;
using WebQuanLyBanHang.Data.Entity;

namespace WebQuanLyBanHang.Service.Interface
{
    public interface IOrderInfoContentService
    {
        public Task<ResponseData<OrderInfoContentVM>> GetAll(Pageding pageding);
        public Task<List<OrderInfoContentVM>> Gets();
        public Task Add(OrderInfoContentVM orderInfoContent);
        public Task Update(OrderInfoContentVM orderInfoContent);
        public Task Delete(int id);
        public Task<OrderInfoContentVM> Get(int id);
        public Task<bool> CheckData(string word);
    }
}

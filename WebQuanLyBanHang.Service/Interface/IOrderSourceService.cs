using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyBanHang.Utilities.ViewModel;
using WebQuanLyBanHang.Utilities;

namespace WebQuanLyBanHang.Service.Interface
{
    public interface IOrderSourceService
    {
        public Task<ResponseData<OrderSourceVM>> GetAll(Pageding pageding);
        public Task<List<OrderSourceVM>> Gets();
        public Task Add(OrderSourceVM orderSource);
        public Task Update(OrderSourceVM orderSource);
        public Task Delete(int id);
        public Task<OrderSourceVM> Get(int id);
        public Task<bool> CheckData(string word);
    }
}

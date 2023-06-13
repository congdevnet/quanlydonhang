using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyBanHang.Utilities.ViewModel;
using WebQuanLyBanHang.Utilities;

namespace WebQuanLyBanHang.Service.Interface
{
    public interface IMethodDeliveryService
    {
        public Task<ResponseData<MethodDeliveryVM>> GetAll(Pageding pageding);
        public Task<List<MethodDeliveryVM>> Gets();
        public Task Add(MethodDeliveryVM methodDelivery);
        public Task Update(MethodDeliveryVM methodDelivery);
        public Task Delete(int id);
        public Task<MethodDeliveryVM> Get(int id);
        public Task<bool> CheckData(string word);
    }
}

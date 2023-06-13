using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyBanHang.Utilities.ViewModel;
using WebQuanLyBanHang.Utilities;

namespace WebQuanLyBanHang.Service.Interface
{
    public interface IGroupCustomerService
    {
        public Task<ResponseData<GroupCustomerVM>> GetAll(Pageding pageding);
        public Task<List<GroupCustomerVM>> Gets();
        public Task Add(GroupCustomerVM groupCustomer);
        public Task Update(GroupCustomerVM groupCustomer);
        public Task Delete(int id);
        public Task<GroupCustomerVM> Get(int id);
        public Task<bool> CheckData(string word);
    }
}

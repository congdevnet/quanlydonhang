using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyBanHang.Utilities.ViewModel;
using WebQuanLyBanHang.Utilities;

namespace WebQuanLyBanHang.Service.Interface
{
    public interface ISingleTypeService
    {
        public Task<ResponseData<SingleTypeVM>> GetAll(Pageding pageding);
        public Task<List<SingleTypeVM>> Gets();
        public Task Add(SingleTypeVM  singleType);
        public Task Update(SingleTypeVM singleType);
        public Task Delete(int id);
        public Task<SingleTypeVM> Get(int id);
        public Task<bool> CheckData(string word);
    }
}

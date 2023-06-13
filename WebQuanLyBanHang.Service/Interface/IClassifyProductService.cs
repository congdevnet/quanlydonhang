using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyBanHang.Utilities.ViewModel;
using WebQuanLyBanHang.Utilities;

namespace WebQuanLyBanHang.Service.Interface
{
    public interface IClassifyProductService
    {
        public Task<ResponseData<ClassifyProductVM>> GetAll(Pageding pageding);
        public Task Add(ClassifyProductVM orderStatus);
        public Task Update(ClassifyProductVM orderStatus);
        public Task Delete(int id);
        public Task<ClassifyProductVM> Get(int id);
        public Task<bool> CheckData(string word);
        public IEnumerable<ClassifyProductVM> GetClassifyProductVMs();
    }
}

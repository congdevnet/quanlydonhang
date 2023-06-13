using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyBanHang.Utilities.ViewModel;
using WebQuanLyBanHang.Utilities;

namespace WebQuanLyBanHang.Service.Interface
{
    public interface IUnitService
    {
        public Task<ResponseData<UnitVM>> GetAll(Pageding pageding);
        public Task Add(UnitVM unitVM);
        public Task Update(UnitVM unitVM);
        public Task Delete(int id);
        public Task<UnitVM> Get(int id);
        public Task<bool> CheckData(string word);
        public IEnumerable<UnitVM> GetUnitVMs();
    }
}

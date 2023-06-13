using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Service.Interface
{
    public interface IStatusProductService
    {
        public IEnumerable<StatusProductVM> Get();
    }
}

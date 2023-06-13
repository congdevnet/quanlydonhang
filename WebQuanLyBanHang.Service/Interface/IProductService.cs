using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyBanHang.Utilities.ViewModel;
using WebQuanLyBanHang.Utilities;
using System.Linq.Expressions;
using WebQuanLyBanHang.Data.Entity;

namespace WebQuanLyBanHang.Service.Interface
{
    public interface IProductService
    {
        public Task<ResponseData<ProductVM>> GetAll(Pageding pageding);
        public Task Add(ProductVM productVM);
        public Task Update(ProductVM productVM);
        public Task Delete(Guid id);
        public Task<ProductVM> Get(Guid id);
        public Task<List<ProductVM>> Gets(Expression<Func<Product, bool>> expression);
        public Task<bool> CheckData(string word);
    }
}

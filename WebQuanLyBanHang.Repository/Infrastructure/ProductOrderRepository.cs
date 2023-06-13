using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyBanHang.Data.EF;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Repository.Interface;

namespace WebQuanLyBanHang.Repository.Infrastructure
{
    public class ProductOrderRepository: Repository<ProductOrder>, IProductOrderRepository
    {
        public ProductOrderRepository(QuanLyBanHangDbContent dbContext) : base(dbContext)
        {
        }
    
    }
}

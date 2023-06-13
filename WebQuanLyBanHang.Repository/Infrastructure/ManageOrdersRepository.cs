using WebQuanLyBanHang.Data.EF;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Repository.Interface;

namespace WebQuanLyBanHang.Repository.Infrastructure
{
    public class ManageOrdersRepository : Repository<ManageOrders>, IManageOrdersRepository
    {
        public ManageOrdersRepository(QuanLyBanHangDbContent dbContext) : base(dbContext)
        {
        }
    }
}
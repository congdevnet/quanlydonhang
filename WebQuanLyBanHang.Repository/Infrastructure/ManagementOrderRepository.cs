using WebQuanLyBanHang.Data.EF;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Repository.Interface;

namespace WebQuanLyBanHang.Repository.Infrastructure
{
    public class ManagementOrderRepository : Repository<ManagementOrder>, IManagementOrderRepository
    {
        public ManagementOrderRepository(QuanLyBanHangDbContent dbContext) : base(dbContext)
        {
        }
    }
}
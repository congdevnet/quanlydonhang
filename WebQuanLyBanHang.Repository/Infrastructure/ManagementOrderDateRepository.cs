using WebQuanLyBanHang.Data.EF;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Repository.Interface;

namespace WebQuanLyBanHang.Repository.Infrastructure
{
    public class ManagementOrderDateRepository : Repository<ManagementOrderDate>, 
        IManagementOrderDateRepository
    {
        public ManagementOrderDateRepository(QuanLyBanHangDbContent dbContext) : base(dbContext)
        {
        }
    }
}
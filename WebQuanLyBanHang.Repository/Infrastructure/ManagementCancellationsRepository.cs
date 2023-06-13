using WebQuanLyBanHang.Data.EF;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Repository.Interface;

namespace WebQuanLyBanHang.Repository.Infrastructure
{
    public class ManagementCancellationsRepository : Repository<ManagementCancellation>, IManagementCancellationsRepository
    {
        public ManagementCancellationsRepository(QuanLyBanHangDbContent dbContext) : base(dbContext)
        {
        }
    }
}
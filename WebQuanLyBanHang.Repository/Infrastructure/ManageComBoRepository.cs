
using WebQuanLyBanHang.Data.EF;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Repository.Interface;

namespace WebQuanLyBanHang.Repository.Infrastructure
{
    public class ManageComBoRepository: Repository<ManageComBo>, IManageComBoRepository
    {
        public ManageComBoRepository(QuanLyBanHangDbContent dbContext) : base(dbContext)
        {
        }
    }

}

using WebQuanLyBanHang.Data.EF;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Repository.Interface;

namespace WebQuanLyBanHang.Repository.Infrastructure
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(QuanLyBanHangDbContent dbContext) : base(dbContext)
        {
        }
    }
}
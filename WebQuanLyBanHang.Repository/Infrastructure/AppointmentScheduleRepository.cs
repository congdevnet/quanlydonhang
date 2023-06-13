using WebQuanLyBanHang.Data.EF;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Repository.Interface;

namespace WebQuanLyBanHang.Repository.Infrastructure
{
    public class AppointmentScheduleRepository : Repository<AppointmentSchedule>, IAppointmentScheduleRepository
    {
        public AppointmentScheduleRepository(QuanLyBanHangDbContent dbContext) : base(dbContext)
        {
        }
    }
}
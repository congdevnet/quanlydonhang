using WebQuanLyBanHang.Utilities.ViewModel;
using WebQuanLyBanHang.Utilities;

namespace WebQuanLyBanHang.Service.Interface
{
	public interface IAppointmentScheduleService
	{
		// Lấy danh sách khách hẹn //
		public Task<ResponseData<AppointmentScheduleView>> GetAll(Pageding pageding);
		public Task Add(AppointmentScheduleVM appointmentSchedule);
		public Task Update(AppointmentScheduleVM appointmentSchedule);
		public Task<AppointmentScheduleVM> Get(int id);
		public Task Delete(int id);


	}
}
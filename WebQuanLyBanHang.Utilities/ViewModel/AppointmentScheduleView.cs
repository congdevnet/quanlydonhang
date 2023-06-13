namespace WebQuanLyBanHang.Utilities.ViewModel
{
	public class AppointmentScheduleView
	{
		public int  Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public DateTime? DateAppointment { get; set; }
		public string Note { get; set; } = string.Empty; // Nội dung hẹn
	}
}
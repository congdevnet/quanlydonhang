using System.ComponentModel.DataAnnotations;

namespace WebQuanLyBanHang.Utilities.ViewModel
{
    public class AppointmentScheduleVM
    {
        public int Id { get; set; }
        public DateTime? AppointmentDate { get; set; } // Ngày hẹn
        public string DateAppointments { get; set; } // Ngày hẹn
        [MaxLength(500, ErrorMessage = "Vượt quá quá 500 ký tự!")]
        public string? Note { get; set; } //nội dung hẹn
        public Guid CustomerId { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
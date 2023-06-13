using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyBanHang.Data.Entity
{
    /// <summary>
    ///  Quản lý lịch hẹn
    /// </summary>
    [Table("AppointmentSchedules")]
    public class AppointmentSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime? AppointmentDate { get; set; }

        [MaxLength(500)]
        public string? Note { get; set; } = string.Empty;

        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = false;

        public Guid CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
    }
}
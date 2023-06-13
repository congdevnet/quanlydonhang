using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebQuanLyBanHang.Common;

namespace WebQuanLyBanHang.Data.Entity
{
    /// <summary>
    /// Table customer
    /// </summary>
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(256)]
        public string? Name { get; set; } = string.Empty;

        [MaxLength(256)]
        public string? Address { get; set; } = string.Empty;

        [MaxLength(256)]
        [EmailAddress]
        public string? Email { get; set; } = string.Empty;

        [MaxLength(12)]
        [MinLength(10)]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        public DateTime? DateOfBirth { get; set; }
        public Gender Gender { get; set; } = Gender.Male;

        [MaxLength(500)]
        public string? Note { get; set; } = string.Empty;

        public double? Age { get; set; } = double.NaN;

        public double? Weight { get; set; } = double.NaN;
        public int? City { get; set; } = int.MinValue;
        public int? District { get; set; } = int.MinValue;
        public int? ward { get; set; } = int.MinValue;
    }
}
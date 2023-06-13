using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyBanHang.Data.Entity
{
    [Table("Suppliers")]
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string SupCode { get; set; } = string.Empty; //mã nhà cung cấp

        [Required]
        [MaxLength(256)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(256)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(12)]
        [MinLength(10)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public int City { get; set; }
    }
}
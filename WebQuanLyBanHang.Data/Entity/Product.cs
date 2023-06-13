using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyBanHang.Data.Entity
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(256)]
        [Required]
        public string ProductCode { get; set; } = string.Empty; // Mã sản phẩm

        [Required]
        public double Quanlity { get; set; } // Số lượng sản phẩm

        public double InventoryNumber { get; set; } /// Số lượng tổn sản phẩm

        [Required]
        [MaxLength(50)]
        public string Barcode { get; set; } = string.Empty; // Mã Code sản phẩm

        [Required]
        [MaxLength(256)]
        public string ProductName { get; set; } = string.Empty; // Tên sản phẩm

        [Required]
        public double Price { get; set; } = double.NaN; // Giá sản phẩm

        public double? InitialPrice { get; set; } = double.NaN; // Giá gốc sản phẩm

        [Required]
        public double Mass { get; set; } = double.NaN; // Khối lượng sản phẩm

        [Required]
        [MaxLength(256)]
        public string Picture { get; set; } = string.Empty; // Tên ảnh sản phẩm

        public DateTime? DateCreated { get; set; } // Ngày tạo sản phẩm
        public DateTime? Expired { get; set; } // Ngày hết hạn sản phẩm
        public int UnitId { get; set; } // Đơn vị khối lượng
        public int StatusProductId { get; set; } /// Trạng thái sản phẩm
        public int ClassifyProductId { get; set; } /// Loại sản phẩm

        [ForeignKey("UnitId")]
        public Unit? Unit { get; set; }
        [ForeignKey("StatusProductId")]
        public StatusProduct? StatusProduct { get; set; }
        [ForeignKey("ClassifyProductId")]
        public ClassifyProduct? ClassifyProduct { get; set; }
    }
}
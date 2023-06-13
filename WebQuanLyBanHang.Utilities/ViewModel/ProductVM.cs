using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WebQuanLyBanHang.Utilities.ViewModel
{
	public class ProductVM
	{
		public Guid Id { get; set; }

		[MaxLength(256,ErrorMessage ="Nhập quá 256 ký tự!")]
		[Required(ErrorMessage ="Nhập mã sản phẩm!")]
		public string ProductCode { get; set; } = string.Empty; // Mã sản phẩm

		[Required(ErrorMessage = "Nhập số lượng sản phẩm!")]
		public double Quanlity { get; set; } // Số lượng sản phẩm

        public double? InventoryNumber { get; set; } /// Số lượng tổn sản phẩm

        [Required(ErrorMessage = "Nhập mã code sản phẩm!")]
        [MaxLength(50, ErrorMessage = "Nhập quá 50 ký tự!")]
        public string Barcode { get; set; } = string.Empty; // Mã Code sản phẩm

        [MaxLength(256, ErrorMessage = "Nhập quá 256 ký tự!")]
        [Required(ErrorMessage = "Nhập tên sản phẩm!")]
        public string ProductName { get; set; } = string.Empty; // Tên sản phẩm

		[Required(ErrorMessage = "Nhập giá bán sản phẩm!")]
		public double Price { get; set; } = double.NaN; // Giá sản phẩm

		public double? InitialPrice { get; set; } = double.NaN; // Giá gốc sản phẩm

        [Required(ErrorMessage = "Nhập khối lượng sản phẩm!")]
        public double Mass { get; set; } = double.NaN; // Khối lượng sản phẩm

        [MaxLength(256, ErrorMessage = "Nhập quá 256 ký tự!")]
        [Required(ErrorMessage = "Nhập ảnh sản phẩm!")]
        public string Picture { get; set; } = string.Empty; // Tên ảnh sản phẩm

		public DateTime? DateCreated { get; set; } // Ngày tạo sản phẩm
		public DateTime? Expired { get; set; } // Ngày hết hạn sản phẩm
        [Required(ErrorMessage = "Chọn đơn vị!")]
        public int UnitId { get; set; } // Đơn vị khối lượng
        [Required(ErrorMessage = "Nhập trạng thái sản phẩm!")]
        public int StatusProductId { get; set; } /// Trạng thái sản phẩm
		[Required(ErrorMessage = "Nhập loại sản phẩm!")]
        public int ClassifyProductId { get; set; } /// Loại sản phẩm
		//[Required(ErrorMessage = "Nhập file ảnh sản phẩm!")]
        public IFormFile? ProductImage { set; get; }
	}
}
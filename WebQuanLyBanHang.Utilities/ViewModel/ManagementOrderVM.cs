using System.ComponentModel.DataAnnotations;

namespace WebQuanLyBanHang.Utilities.ViewModel
{
    public class ManagementOrderVM
    {
        public Guid OrderId { get; set; }
        /// </summary>
        [Required(ErrorMessage = "Không được bỏ trống trường này!")]
        public int OrderInfoContentId { get; set; } /// Nội thành, Nội bộ, khuyến mãi
        [Required(ErrorMessage = "Không được bỏ trống trường này!")]
        public int OrderStatusId { get; set; } = ConstPrameter.OrderStatusOrderId; /// Trạng thái đơn hàng
        [Required(ErrorMessage = "Không được bỏ trống trường này!")]
        public int MethodDeliveryId { get; set; }  /// Hình thức Giao hàng
        [Required(ErrorMessage = "Không được bỏ trống trường này!")]
        public int OrderSourceId { get; set; } /// Nguồn đơn hàng
        [Required(ErrorMessage = "Không được bỏ trống trường này!")]
        public int SingleTypeId { get; set; } /// Loại đơn
        public string? Note { get; set; } = string.Empty; /// Lý Do Hủy / xem xét lại

    }
}
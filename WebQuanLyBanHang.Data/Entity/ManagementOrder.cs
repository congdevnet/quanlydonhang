using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyBanHang.Data.Entity
{
    [Table("ManagementOrders")]
    public class ManagementOrder
    {
        [Key]
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }
        public int OrderInfoContentId { get; set; } = 1; /// Nội thành, Nội bộ, khuyến mãi
        public int OrderStatusId { get; set; } = 1;  /// Trạng thái đơn hàng
        public int MethodDeliveryId { get; set; } = 1;  /// Hình thức Giao hàng
        public int OrderSourceId { get; set; } = 1; /// Nguồn đơn hàng
        public int SingleTypeId { get; set; } = 1; /// Loại đơn

        [MaxLength(500)]
        public string? Note { get; set; } = string.Empty; /// Lý Do Hủy / xem xét lại

        [ForeignKey("OrderId")]
        public Order? Order { get; set; }

        [ForeignKey("OrderInfoContentId")]
        public OrderInfoContent? OrderInfoContent { get; set; }

        [ForeignKey("OrderStatusId")]
        public OrderStatus? OrderStatus { get; set; }

        [ForeignKey("MethodDeliveryId")]
        public MethodDelivery? MethodDelivery { get; set; }

        [ForeignKey("OrderSourceId")]
        public OrderSource? OrderSource { get; set; }

        [ForeignKey("SingleTypeId")]
        public SingleType? SingleType { get; set; }
    }
}
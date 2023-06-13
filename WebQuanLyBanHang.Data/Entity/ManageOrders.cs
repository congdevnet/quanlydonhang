using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyBanHang.Data.Entity
{
    [Table("ManageOrderss")]
    public class ManageOrders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public bool IsOrderActive { get; set; } // kiểm tra xem khách được lên đơn chưa.

        [ForeignKey(nameof(OrderId))]
        public Order? Order { get; set; }

       
        [ForeignKey(nameof(CustomerId))]
        public Customer? Customer { get; set; }

        public DateTime? ApplicationDate { get; set; } = DateTime.Now;
    }
}
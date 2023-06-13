using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyBanHang.Data.Entity
{
    [Table("CustomerManages")]
    public class CustomerManage
    {
        public Guid Id { get; set; }

        public Guid? StaffMKTId { get; set; }
        public Guid? StaffSaleId { get; set; }
        public DateTime? DateAdded { get; set; } = DateTime.Now;
        public DateTime? SplitDate { get; set; } = DateTime.Now;
        public int CustomerStatusId { get; set; }
        public int GroupCustomerId { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? SplitUserId { get; set; }

        [ForeignKey(nameof(CustomerStatusId))]
        public CustomerStatus? CustomerStatus { get; set; }
        [ForeignKey(nameof(GroupCustomerId))]
        public GroupCustomer? GroupCustomer { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer? Customer { get; set; }
    }
}
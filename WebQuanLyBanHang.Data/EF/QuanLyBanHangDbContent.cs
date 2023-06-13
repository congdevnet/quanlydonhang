using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Data.Extend;

namespace WebQuanLyBanHang.Data.EF
{
    /// <summary>
    /// </summary>
    public class QuanLyBanHangDbContent : IdentityDbContext<User, Role, Guid>
    {
        public QuanLyBanHangDbContent(DbContextOptions options) : base(options)
        {
        }

        // Khai bao cac dataset
        public DbSet<AppointmentSchedule> AppointmentSchedules { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        // public DbSet<ComboProduct> ComboProducts { get; set; }
        public DbSet<ClassifyProduct> ClassifyProducts { get; set; }

        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        public DbSet<ExpenseOrder> ExpenseOrders { get; set; }
        public DbSet<GroupCustomer> GroupCustomers { get; set; }

        // public DbSet<ManageComBo> ManageComBos { get; set; }
        public DbSet<MethodDelivery> MethodDeliveries { get; set; }
        public DbSet<ManageOrders> ManageOrders { get; set; }
        public DbSet<ManagementCancellation> ManagementCancellations { get; set; }
        public DbSet<ManagementOrder> ManagementOrders { get; set; }
        public DbSet<ManagementOrderDate> ManagementOrderDates { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderInfoContent> OrderInfoContents { get; set; }
        public DbSet<OrderSource> OrderSources { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }

        // public DbSet<Payments> Payments { get; set; }
        // public DbSet<Prepayment> Prepayments { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }

        public DbSet<SingleType> SingleTypes { get; set; }
        public DbSet<StatusProduct> StatusProducts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<CustomerStatus> CustomerStatuses { get; set; }
        public DbSet<CustomerManage> CustomerManages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRole").HasKey(x => new { x.RoleId, x.UserId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogin").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaim");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserToken").HasKey(x => x.UserId);

            //Send data
            modelBuilder.Send();
        }
    }
}
using WebQuanLyBanHang.Data.EF;
using WebQuanLyBanHang.Models;
using WebQuanLyBanHang.Repository.Infrastructure;
using WebQuanLyBanHang.Repository.Interface;
using WebQuanLyBanHang.Service.Infrastructure;
using WebQuanLyBanHang.Service.Interface;

namespace WebQuanLyBanHang.DependencyInjection
{
    public static class DependencyInjections
    {
        public static void Configuration(this IServiceCollection services) 
        {
            ///UnitOfWork ///
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            ///Repository///
            services.AddTransient<IOrderStatusRepository, OrderStatusRepository>();
            services.AddTransient<IAppointmentScheduleRepository, AppointmentScheduleRepository>();
            services.AddTransient<IClassifyProductRepository, ClassifyProductRepository>();
            services.AddTransient<IComboProductRepository, ComboProductRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IDeliveryAddressRepository, DeliveryAddressRepository>();
            services.AddTransient<IExpenseOrderRepository, ExpenseOrderRepository>();
            services.AddTransient<IGroupCustomerRepository, GroupCustomerRepository>();
            services.AddTransient<IManageComBoRepository, ManageComBoRepository>();
            services.AddTransient<IMethodDeliveryRepository, MethodDeliveryRepository>(); 
            services.AddTransient<IOrderInfoContentRepository, OrderInfoContentRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderSourceRepository, OrderSourceRepository>();
            services.AddTransient<IOrderStatusRepository, OrderStatusRepository>();
            services.AddTransient<IPaymentsRepository, PaymentsRepository>();
            services.AddTransient<IPrepaymentRepository, PrepaymentRepository>();
            services.AddTransient<IProductOrderRepository, ProductOrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ISingleTypeRepository, SingleTypeRepository>();
            services.AddTransient<IStatusProductRepository, StatusProductRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<IUnitRepository, UnitRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICustomerManageRepository, CustomerManageRepository>();
            services.AddTransient<ICustomerStatusRepsitory, CustomerStatusRepsitory>();
            services.AddTransient<IWarehouseRepository, WarehouseRepository>();
            services.AddTransient<IManageOrdersRepository, ManageOrdersRepository>();
            services.AddTransient<IManagementOrderRepository, ManagementOrderRepository>();
            services.AddTransient<IManagementOrderDateRepository, ManagementOrderDateRepository>();
            services.AddTransient<IManagementCancellationsRepository, ManagementCancellationsRepository>();

            ///Service///
            services.AddTransient<IOrderStatusService, OrderStatusService>();
            services.AddTransient<IOrderStatusService, OrderStatusService>();
            services.AddTransient<IAppointmentScheduleService, AppointmentScheduleService>();
            services.AddTransient<IClassifyProductService, ClassifyProductService>();
            services.AddTransient<IComboProductService, ComboProductService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IDeliveryAddressService, DeliveryAddressService>();
            services.AddTransient<IExpenseOrderService, ExpenseOrderService>();
            services.AddTransient<IGroupCustomerService, GroupCustomerService>();
            services.AddTransient<IManageComBoService, ManageComBoService>();
            services.AddTransient<IMethodDeliveryService, MethodDeliveryService>();
            services.AddTransient<IOrderInfoContentService, OrderInfoContentService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderSourceService, OrderSourceService>();
            services.AddTransient<IOrderStatusService, OrderStatusService>();
            services.AddTransient<IPaymentsService, PaymentsService>();
            services.AddTransient<IPrepaymentService, PrepaymentService>();
            services.AddTransient<IProductOrderService, ProductOrderService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<ISingleTypeService, SingleTypeService>();
            services.AddTransient<IStatusProductService, StatusProductService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<IUnitService, UnitService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICustomerManageService, CustomerManageService>();
            services.AddTransient<IWarehouseService, WarehouseService>();
            services.AddTransient<IProvincesService, ProvincesService>();
            services.AddTransient<ICartService, CartService>();
			services.AddTransient<ICustomerStatusService, CustomerStatusService>();
			

		}
    }
}

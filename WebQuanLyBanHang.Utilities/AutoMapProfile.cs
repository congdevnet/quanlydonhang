using AutoMapper;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Utilities
{
    public class AutoMapProfile : Profile
    {
        public AutoMapProfile()
        {
            CreateMap<OrderStatusVM, OrderStatus>().ReverseMap();
            CreateMap<OrderStatus, OrderStatusVM>().ReverseMap();

            CreateMap<MethodDeliveryVM, MethodDelivery>().ReverseMap();
            CreateMap<MethodDelivery, MethodDeliveryVM>().ReverseMap();

            CreateMap<OrderSourceVM, OrderSource>().ReverseMap();
            CreateMap<OrderSource, OrderSourceVM>().ReverseMap();

            CreateMap<ClassifyProductVM, ClassifyProduct>().ReverseMap();
            CreateMap<ClassifyProduct, ClassifyProductVM>().ReverseMap();

            CreateMap<UnitVM, Unit>().ReverseMap();
            CreateMap<Unit, UnitVM>().ReverseMap();

            CreateMap<ProductVM, Product>().ReverseMap();
            CreateMap<Product, ProductVM>().ReverseMap();

            CreateMap<StatusProductVM, StatusProduct>().ReverseMap();
            CreateMap<StatusProduct, StatusProductVM>().ReverseMap();

            CreateMap<GroupCustomerVM, GroupCustomer>().ReverseMap();
            CreateMap<GroupCustomer, GroupCustomerVM>().ReverseMap();

            CreateMap<CustomerMKTVM, Customer>().ReverseMap();
            CreateMap<Customer, CustomerVM>().ReverseMap();

            CreateMap<CustomerManageVM, CustomerManage>().ReverseMap();

            CreateMap<OrderInfoContent, OrderInfoContentVM>().ReverseMap();
            CreateMap<OrderInfoContentVM, OrderInfoContent>().ReverseMap();

            CreateMap<SingleType, SingleTypeVM>().ReverseMap();
            CreateMap<SingleTypeVM, SingleType>().ReverseMap();

            CreateMap<OrderInformationVM, Order>().ReverseMap();
            CreateMap<ProductOrderVM, ProductOrder>().ReverseMap();

            CreateMap<ExpenseOrderVM, ExpenseOrder>().ReverseMap();
            CreateMap<ExpenseOrder, ExpenseOrderVM>().ReverseMap();
            CreateMap<ManageOrdersVM, ManageOrders>().ReverseMap();

            CreateMap<CustomerOrder, Customer>()
                .ForMember(x => x.Id, o => o.MapFrom(s => s.CusId))
                .ForMember(x => x.Email, o => o.MapFrom(s => s.CusEmail))
                .ForMember(x => x.Address, o => o.MapFrom(s => s.CusAddress))
                .ForMember(x => x.PhoneNumber, o => o.MapFrom(s => s.CusPhoneNumber))
                .ForMember(x => x.DateOfBirth, o => o.MapFrom(s => s.DateOfBirth))
                .ForMember(x => x.Age, o => o.MapFrom(s => s.CusAge))
                .ForMember(x => x.City, o => o.MapFrom(s => s.CusCity))
                .ForMember(x => x.District, o => o.MapFrom(s => s.CusDistrict))
                .ForMember(x => x.Gender, o => o.MapFrom(s => s.CusGender))
                .ForMember(x => x.Name, o => o.MapFrom(s => s.CusName))
                .ForMember(x => x.ward, o => o.MapFrom(s => s.Cusward))
                .ForMember(x => x.Weight, o => o.MapFrom(s => s.CusWeight));

            CreateMap<Customer, CustomerOrder>()
               .ForMember(x => x.CusId, o => o.MapFrom(s => s.Id))
               .ForMember(x => x.CusEmail, o => o.MapFrom(s => s.Email))
               .ForMember(x => x.CusAddress, o => o.MapFrom(s => s.Address))
               .ForMember(x => x.CusPhoneNumber, o => o.MapFrom(s => s.PhoneNumber))
               .ForMember(x => x.DateOfBirth, o => o.MapFrom(s => s.DateOfBirth))
               .ForMember(x => x.CusAge, o => o.MapFrom(s => s.Age))
               .ForMember(x => x.CusCity, o => o.MapFrom(s => s.City))
               .ForMember(x => x.CusDistrict, o => o.MapFrom(s => s.District))
               .ForMember(x => x.CusGender, o => o.MapFrom(s => s.Gender))
               .ForMember(x => x.CusName, o => o.MapFrom(s => s.Name))
               .ForMember(x => x.Cusward, o => o.MapFrom(s => s.ward))
               .ForMember(x => x.CusWeight, o => o.MapFrom(s => s.Weight));

            CreateMap<AppointmentScheduleVM, AppointmentSchedule>().ReverseMap();
            CreateMap<ManagementOrderVM, ManagementOrder>().ReverseMap();
            CreateMap<ManagementCancellationsVM, ManagementCancellation>().ReverseMap();
            CreateMap<ManagementOrderDatesVM, ManagementOrderDate>().ReverseMap();
            CreateMap<OrderVM, Order>().ReverseMap();
            CreateMap<CanceledOrderVM, ManagementCancellation>().ReverseMap();
            CreateMap<User, UserVM>().ReverseMap();
            CreateMap<UserVM, User>().ReverseMap();
        }
    }
}
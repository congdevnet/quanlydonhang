using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Repository.Infrastructure;
using WebQuanLyBanHang.Repository.Interface;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Service.Infrastructure
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductOrderRepository _productOrderRepository;
        private readonly IExpenseOrderRepository _expenseOrderRepository;
        private readonly IManageOrdersRepository _manageOrdersRepository;
        private readonly IManagementOrderRepository _managementOrderRepository;
        private readonly IManagementOrderDateRepository _managementOrderDateRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerManageRepository _customerManageRepository;
        private readonly UserManager<User> _userManager;
        private readonly IManagementCancellationsRepository _managementCancellationsRepository;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper,
            ICustomerRepository customerRepository, IOrderRepository orderRepository,
            IProductOrderRepository productOrderRepository,
            IExpenseOrderRepository expenseOrderRepository,
            IManageOrdersRepository manageOrdersRepository,
            IManagementOrderRepository managementOrderRepository,
            IManagementOrderDateRepository managementOrderDateRepository,
            IProductRepository productRepository, 
            ICustomerManageRepository customerManageRepository, UserManager<User> userManager,
            IManagementCancellationsRepository managementCancellationsRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _productOrderRepository = productOrderRepository;
            _expenseOrderRepository = expenseOrderRepository;
            _manageOrdersRepository = manageOrdersRepository;
            _managementOrderRepository = managementOrderRepository;
            _managementOrderDateRepository = managementOrderDateRepository;
            _productRepository = productRepository;
            _customerManageRepository = customerManageRepository;
            _userManager = userManager;
            _managementCancellationsRepository = managementCancellationsRepository;
        }

        public async Task Add(OrderVM orderVM, Guid customerId)
        {
            try
            {
                var data = _mapper.Map<Order>(orderVM);
                _orderRepository.Add(data);
                await _unitOfWork.CommitAsync();
                ManageOrdersVM manageOrders = new ManageOrdersVM(data.Id, customerId,
                    DateTime.Now, true);
                await AddManageOrderss(manageOrders);
            }
            catch
            {
                _unitOfWork.Rollback();
            }
        }

        public async Task AddCanceledOrder(CanceledOrderVM canceledOrder)
        {
            
            try
            {
                // Xóa hết thông tin đơn hàng
                // Delete data table ExpenseOrders
                var dataExpenseOrders = _expenseOrderRepository.Get(x => x.OrderId == canceledOrder.OrderId);
                if (dataExpenseOrders != null)
                {
                    _expenseOrderRepository.Remove(dataExpenseOrders);
                }
                // Delete data table ManagementOrderDates
                var dataManagementOrderDates = _managementOrderDateRepository.Get(x => x.OrderId == canceledOrder.OrderId);
                if (dataManagementOrderDates != null)
                {
                    _managementOrderDateRepository.Remove(dataManagementOrderDates);
                }
                // Delete data table ManagementOrders
                var dataManagementOrders = _managementOrderRepository.Get(x => x.OrderId == canceledOrder.OrderId);
                if (dataManagementOrders != null)
                {
                    _managementOrderRepository.Remove(dataManagementOrders);
                }
                // Delete data table ManageOrderss
                var dataManageOrderss = _manageOrdersRepository.Get(x => x.OrderId == canceledOrder.OrderId);
                if (dataManageOrderss != null)
                {
                    _manageOrdersRepository.Remove(dataManageOrderss);
                }
                // Delete data table ProductOrders
                List<ProductOrder> dataProductOrders = new List<ProductOrder>();
                dataProductOrders = _productOrderRepository.GetAll(x => x.OrderId == canceledOrder.OrderId).ToList();
                if (dataProductOrders.Count > 0)
                {
                    // Update data table Product //
                    foreach (var item in dataProductOrders)
                    {
                        var dataProduct = _productRepository.Get(x => x.Id == item.ProductId);
                        dataProduct.InventoryNumber += item.Quantity;
                        _productRepository.Update(dataProduct);
                    }
                    _productOrderRepository.RemoveRange(dataProductOrders);
                }
                // Delete data table Order
                var dataOrder = _orderRepository.Get(x => x.Id == canceledOrder.OrderId);
                if (dataOrder != null)
                {
                    _orderRepository.Remove(dataOrder);
                }
                //Cập nhật trạng thái khách bom hàng
                var datacustomerManage = _customerManageRepository.Get(x => x.CustomerId == dataManageOrderss.CustomerId);
                if (datacustomerManage != null)
                {
                    datacustomerManage.CustomerStatusId = ConstPrameter.CustomerStatusBom;
                    _customerManageRepository.Update(datacustomerManage);
                }
                // Thêm vào phân hủy đơn 
                canceledOrder.CustomerId = dataManageOrderss.CustomerId;
                var dataCanceledOrder = _managementCancellationsRepository.Get(x => x.CustomerId == dataManageOrderss.CustomerId);
                if (dataCanceledOrder == null)
                {
                    var data = _mapper.Map<CanceledOrderVM, ManagementCancellation>(canceledOrder);
                    _managementCancellationsRepository.Add(data);
                }
                else
                {
                    canceledOrder.Id = dataCanceledOrder.Id;
                    var data = _mapper.Map<CanceledOrderVM, ManagementCancellation>(canceledOrder,
                        dataCanceledOrder);
                    _managementCancellationsRepository.Update(data);
                }
                //
                await  _unitOfWork.CommitAsync();
            }
            catch
            {
                _unitOfWork.Rollback();
            }
        }

        public async Task AddOrder(OrderInformationVM orderInformationVM, Guid userId)
        {
            try
            {
                // Update Customers ///
                Customer customer = _mapper.Map<CustomerOrder, Customer>
                    (orderInformationVM.CustomerOrder);

                _customerRepository.Update(customer);
                /// Add table ProductOrders ///
                List<ProductOrderVM> productOrders = new List<ProductOrderVM>();

                foreach (var item in orderInformationVM.CartItems)
                {
                    ProductOrderVM productOrder = new ProductOrderVM();
                    productOrder.OrderId = orderInformationVM.OrderId;
                    productOrder.ProductId = item.ProductId;
                    productOrder.Quantity = item.Quantity;
                    // Update quanlity trong product //
                    var dataProduct = _productRepository.Get(x => x.Id == item.ProductId);
                    dataProduct.InventoryNumber = dataProduct.Quanlity - item.Quantity;

                    _productRepository.Update(dataProduct);

                    productOrders.Add(productOrder);
                };
                List<ProductOrder> products =
                        _mapper.Map<List<ProductOrderVM>, List<ProductOrder>>(productOrders);

                _productOrderRepository.AddRange(products);

                // add table ExpenseOrders
                if (!orderInformationVM.ExpenseOrderVM.IntoMoney.Equals(0))
                {
                    orderInformationVM.ExpenseOrderVM.OrderId = orderInformationVM.OrderId;

                    ExpenseOrder expenseOrder = _mapper.Map<ExpenseOrderVM, ExpenseOrder>
                    (orderInformationVM.ExpenseOrderVM);

                    _expenseOrderRepository.Add(expenseOrder);
                }
                // add table ManagementOrders
                orderInformationVM.ManagementOrderVM.OrderId = orderInformationVM.OrderId;
                ManagementOrder managementOrder = _mapper.Map<ManagementOrderVM, ManagementOrder>
                    (orderInformationVM.ManagementOrderVM);

                _managementOrderRepository.Add(managementOrder);

                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
        }

        /// <summary>
        ///  Delete don hang ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task Delete(Guid id)
        {
            try
            {
                // Delete data table ExpenseOrders
                var dataExpenseOrders = _expenseOrderRepository.Get(x => x.OrderId == id);
                if (dataExpenseOrders != null)
                {
                    _expenseOrderRepository.Remove(dataExpenseOrders);
                }
                // Delete data table ManagementOrderDates
                var dataManagementOrderDates = _managementOrderDateRepository.Get(x => x.OrderId == id);
                if (dataManagementOrderDates != null)
                {
                    _managementOrderDateRepository.Remove(dataManagementOrderDates);
                }
                // Delete data table ManagementOrders
                var dataManagementOrders = _managementOrderRepository.Get(x => x.OrderId == id);
                if (dataManagementOrders != null)
                {
                    _managementOrderRepository.Remove(dataManagementOrders);
                }
                // Delete data table ManageOrderss
                var dataManageOrderss = _manageOrdersRepository.Get(x => x.OrderId == id);
                if (dataManageOrderss != null)
                {
                    _manageOrdersRepository.Remove(dataManageOrderss);
                }
                // Delete data table ProductOrders
                List<ProductOrder> dataProductOrders = new List<ProductOrder>();
                dataProductOrders = _productOrderRepository.GetAll(x => x.OrderId == id).ToList();
                if (dataProductOrders.Count > 0)
                {
                    // Update data table Product //
                    foreach (var item in dataProductOrders)
                    {
                        var dataProduct = _productRepository.Get(x => x.Id == item.ProductId);
                        dataProduct.InventoryNumber += item.Quantity;
                        _productRepository.Update(dataProduct);
                    }
                    _productOrderRepository.RemoveRange(dataProductOrders);
                }
                // Delete data table Order
                var dataOrder = _orderRepository.Get(x => x.Id == id);
                if (dataOrder != null)
                {
                    _orderRepository.Remove(dataOrder);
                }

                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
            }
        }

        public async Task EditOrder(OrderInformationVM orderVM)
        {
            try
            {
                // Update Customers ///
                Customer customer = _mapper.Map<CustomerOrder, Customer>
                    (orderVM.CustomerOrder);

                _customerRepository.Update(customer);

                // update table ExpenseOrders
                var dataExpenseOrder = _expenseOrderRepository.Get(x => x.OrderId == orderVM.OrderId);

                if (dataExpenseOrder != null)
                {
                    orderVM.ExpenseOrderVM.OrderId = orderVM.OrderId;

                    ExpenseOrder expenseOrder = _mapper.Map<ExpenseOrderVM, ExpenseOrder>
                    (orderVM.ExpenseOrderVM, dataExpenseOrder);

                    _expenseOrderRepository.Update(expenseOrder);
                }
                else
                {
                    orderVM.ExpenseOrderVM.OrderId = orderVM.OrderId;

                    ExpenseOrder expenseOrder = _mapper.Map<ExpenseOrderVM, ExpenseOrder>
                    (orderVM.ExpenseOrderVM);

                    _expenseOrderRepository.Add(expenseOrder);
                }
                var datamanagementOrder = _managementOrderRepository.Get(x => x.OrderId == orderVM.OrderId);
                if (datamanagementOrder != null)
                {
                    // update table ManagementOrders
                    orderVM.ManagementOrderVM.OrderId = orderVM.OrderId;
                    ManagementOrder managementOrder = _mapper.Map<ManagementOrderVM, ManagementOrder>
                        (orderVM.ManagementOrderVM, datamanagementOrder);

                    _managementOrderRepository.Update(managementOrder);
                }
                // Khi đơn hàng xác nhận đặt hàng đến chốt đơn //
                if (orderVM.ManagementOrderVM.OrderStatusId >= ConstPrameter.OrderStatusOrderId &&
                    orderVM.ManagementOrderVM.OrderStatusId <= ConstPrameter.OrderStatuslatchOrderId)
                {
                    var datamanagementOrderDates = _managementOrderDateRepository.Get(x => x.OrderId == orderVM.OrderId);
                    if (datamanagementOrderDates == null)
                    {
                        ManagementOrderDatesVM managementOrderDates = new ManagementOrderDatesVM
                       (orderVM.OrderId, DateTime.Now);
                        // add table ManagementOrderDates
                        ManagementOrderDate managementOrderDate =
                            _mapper.Map<ManagementOrderDatesVM, ManagementOrderDate>
                        (managementOrderDates);

                        _managementOrderDateRepository.Add(managementOrderDate);
                    }
                }

                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
        }
        public async Task<List<CartItem>> GetCartItem(Guid id)
        {
            List<CartItem> cartItems = new List<CartItem>();
            // Thong tin san pham //
            var dataProductOrder = from proOrd in _productOrderRepository.GetAll()
                                   join pro in _productRepository.GetAll()
                                   on proOrd.ProductId equals pro.Id
                                   where proOrd.OrderId == id
                                   select new CartItem
                                   {
                                       OrderDetailsId = proOrd.Id,
                                       Price = pro.Price,
                                       ProductId = pro.Id,
                                       ProductName = pro.ProductName,
                                       Quantity = (int)proOrd.Quantity,
                                       UnitPrice = proOrd.Quantity * pro.Price,
                                   };
            cartItems = await dataProductOrder.ToListAsync();
            return cartItems;
        }

        public async Task<bool> GetCheckOrder(Guid id)
        {
            var data = await _manageOrdersRepository.GetAsync(x => x.CustomerId == id);
            if (data == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<CustomerOrders> GetCustomerOrders(Guid id)
        {
            CustomerOrders customerOrders = new CustomerOrders();
            try
            {
                var data = from o in _orderRepository.GetAll()
                           join moc in _manageOrdersRepository.GetAll()
                           on o.Id equals moc.OrderId
                           join cu in _customerRepository.GetAll()
                           on moc.CustomerId equals cu.Id
                           where cu.Id == id
                           select new CustomerOrders
                           {
                               OrderId = o.Id,
                               CusAddress = cu.Address,
                               CusAge = cu.Age,
                               CusEmail = cu.Email,
                               CusId = cu.Id,
                               CusName = cu.Name,
                               CusPhoneNumber = cu.PhoneNumber,
                               CustomerId = cu.Id,
                               CusWeight = cu.Weight,
                               IsOrderActive = moc.IsOrderActive
                           };
                customerOrders = await data.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                return new CustomerOrders();
            }
            return customerOrders;
        }

        public async Task<OrderInformationVM> GetOrder(Guid id)
        {
            OrderInformationVM orderInformationVM = new OrderInformationVM();
            try
            {
                // Thông tin khách hàng //
                var dataCustomer = _manageOrdersRepository.Get(x => x.OrderId == id);

                orderInformationVM.OrderId = dataCustomer.OrderId;

                Customer customer = _customerRepository.Get(x => x.Id == dataCustomer.CustomerId);

                orderInformationVM.CustomerOrder = _mapper.Map<Customer, CustomerOrder>(customer);

                // Thong tin thanh toan //
                var dataExpenseOrder = _expenseOrderRepository.Get(x => x.OrderId == id);

                orderInformationVM.ExpenseOrderVM = _mapper.Map<ExpenseOrder, ExpenseOrderVM>
                    (dataExpenseOrder);

                // Thong tin ManagementOrderVM //
                var dataManagementOrder = _managementOrderRepository.Get(x => x.OrderId == id);

                orderInformationVM.ManagementOrderVM = _mapper.Map<ManagementOrder, ManagementOrderVM>
                    (dataManagementOrder);
            }
            catch (Exception ex)
            {
                return new OrderInformationVM();
            }
            return orderInformationVM;
        }

        public async Task<OrderInformationVM> GetOrderInformation(Guid id)
        {
            var data = await GetCustomerOrders(id).ConfigureAwait(false);

            OrderInformationVM orderInformationVM = new OrderInformationVM();
            if (data != null)
            {
                orderInformationVM.OrderId = data.OrderId;
                orderInformationVM.IsOrderActive = data.IsOrderActive;
                orderInformationVM.CustomerOrder.CusPhoneNumber = data.CusPhoneNumber;
                orderInformationVM.CustomerOrder.CusAddress = data.CusAddress;
                orderInformationVM.CustomerOrder.CusAge = data.CusAge;
                orderInformationVM.CustomerOrder.CusWeight = data.CusWeight;
                orderInformationVM.CustomerOrder.CusEmail = data.CusEmail;
                orderInformationVM.CustomerOrder.CusId = data.CusId;
            }

            return orderInformationVM;
        }

        public async Task<ResponseData<OrderDetailed>> GetOrderOrder(PagedingMKT pageding)
        {
            try
            {
                ResponseData<OrderDetailed> response = new ResponseData<OrderDetailed>();

                var data = from cus in _customerRepository.GetAll()
                           join cusma in _customerManageRepository.GetAll()
                           on cus.Id equals cusma.CustomerId
                           join usemkt in _userManager.Users
                           on cusma.StaffMKTId equals usemkt.Id
                           join usesale in _userManager.Users
                           on cusma.StaffSaleId equals usesale.Id into ps_staffsale
                           from ps in ps_staffsale.DefaultIfEmpty()
                           join maord in _manageOrdersRepository.GetAll()
                           on cus.Id equals maord.CustomerId
                           join maordr in _managementOrderRepository.GetAll()
                           on maord.OrderId equals maordr.OrderId

                           where cusma.StaffSaleId == pageding.UserId
                           && !cusma.StaffSaleId.Value.Equals(ConstPrameter.Guiddefault)

                           select new OrderDetailed()
                           {
                               OrderId = maord.OrderId,
                               CustomerId = cus.Id,
                               Address = cus.Address,
                               CustomerEmail = cus.Email,
                               CustomerName = cus.Name,
                               CustomerPhone = cus.PhoneNumber,
                               OrderDate = maord.ApplicationDate,
                               OrderStatus = maordr.OrderStatus.Name,
                               CityId = cus.City,
                               DistrictId = cus.District,
                               OderStatusId = maordr.OrderStatus.Id,
                               WardId = cus.ward
                           };
                if (!string.IsNullOrEmpty(pageding.KeyWord))
                {
                    data = data.Where(x => x.CustomerPhone.Contains(pageding.KeyWord)
                    || x.CustomerEmail.Contains(pageding.KeyWord)
                    || x.CustomerName.Contains(pageding.KeyWord)
                    );
                };
                if (pageding.StartDay != null && pageding.EndDay != null)
                {
                    //Xử ly thoi gian
                    pageding.EndDay = pageding.EndDay.Value.AddDays(1);
                    data = data.Where(x => x.OrderDate >= pageding.StartDay
                    && x.OrderDate <= pageding.EndDay);
                };
                if (pageding.OrderStatus > 0)
                {
                    data = data.Where(x => x.OderStatusId == pageding.OrderStatus);
                };
                int toltalpages = (int)Math.Ceiling((await data.CountAsync() * 1.0 / pageding.PageSize));
                data = data.OrderByDescending(x => x.OrderDate)
                            .Skip(pageding.PageSize * (pageding.PageNum - 1))
                            .Take(pageding.PageSize);

                var list = await data.ToListAsync();

                response.TotalPage = toltalpages;
                response.PageIndex = pageding.PageNum;
                response.Items = list;
                return response;
            }
            catch
            {
                return new ResponseData<OrderDetailed>();
            }
        }
        public async Task UpdateConfirm(Guid id, int orderstatus)
        {
            try
            {
                var datamanagementOrders = _managementOrderRepository.Get(x => x.OrderId == id);
                if (datamanagementOrders != null)
                {
                    datamanagementOrders.OrderStatusId = orderstatus;
                }

                var datamanagementOrderDate =
                       _managementOrderDateRepository.Get(x => x.OrderId == id);
                if (datamanagementOrderDate == null)
                {
                    ManagementOrderDatesVM managementOrderDates = new ManagementOrderDatesVM
                        (id, DateTime.Now);

                    managementOrderDates.ConfirmationDate = managementOrderDates.FinishDay
                        = managementOrderDates.DayShipping = DateTime.Now;

                    // add table ManagementOrderDates
                    ManagementOrderDate managementOrderDate =
                        _mapper.Map<ManagementOrderDatesVM, ManagementOrderDate>
                    (managementOrderDates);

                    _managementOrderDateRepository.Add(managementOrderDate);
                }
                else
                {
                    switch (orderstatus)
                    {
                        case (int)OrderEnum.SingleClosing:
                            datamanagementOrderDate.ClosingDate = DateTime.Now;
                            break;
                        case (int)OrderEnum.Transport:
                            datamanagementOrderDate.DayShipping = DateTime.Now;
                            break;
                        case (int)OrderEnum.Complete:
                            datamanagementOrderDate.FinishDay = DateTime.Now;
                            break;
                        default:
                            break;
                    }

                }
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                _unitOfWork.Rollback();
            }
        }
        private async Task AddManageOrderss(ManageOrdersVM manageOrders)
        {
            try
            {
                var data = _mapper.Map<ManageOrders>(manageOrders);
                _manageOrdersRepository.Add(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
        }
    }
}
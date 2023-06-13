using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Repository.Interface;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Service.Infrastructure
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerManageRepository _customerManageRepository;
        private readonly UserManager<User> _userManager;
        private readonly ICustomerStatusRepsitory _customerStatusRepsitory;
        private readonly IOrderRepository _orderRepository;
        private readonly IManageOrdersRepository _manageOrdersRepository;
        private readonly IManagementOrderRepository _managementOrderRepository;
        private readonly IAppointmentScheduleRepository _appointmentScheduleRepository;
        private readonly IManagementCancellationsRepository _managementCancellationsRepository;
        public CustomerService(IUnitOfWork unitOfWork,
            ICustomerRepository customerRepository, IMapper mapper,
            ICustomerManageRepository customerManageRepository,
            UserManager<User> userManager,
            ICustomerStatusRepsitory customerStatusRepsitory,
            IOrderRepository orderRepository,
            IManageOrdersRepository manageOrdersRepository,
            IManagementOrderRepository managementOrderRepository,
            IAppointmentScheduleRepository appointmentScheduleRepository,
            IManagementCancellationsRepository managementCancellationsRepository)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _mapper = mapper;
            _customerManageRepository = customerManageRepository;
            _userManager = userManager;
            _customerStatusRepsitory = customerStatusRepsitory;
            _orderRepository = orderRepository;
            _manageOrdersRepository = manageOrdersRepository;
            _managementOrderRepository = managementOrderRepository;
            _appointmentScheduleRepository = appointmentScheduleRepository;
            _managementCancellationsRepository = managementCancellationsRepository;
        }

        public async Task Add(CustomerMKTVM Customer)
        {
            try
            {
                var data = _mapper.Map<Customer>(Customer);
                await _customerRepository.AddAsync(data);
                _unitOfWork.Commit();
                await AddCustomerManage(Customer.UserId, data.Id);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
        }

        public async Task<bool> CheckData(string word)
        {
            return await _customerRepository.CheckWord(x => x.PhoneNumber == word);
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var data = await _customerRepository.GetAsync(x => x.Id == id);
                _customerRepository.Remove(data);
                var model = await _customerManageRepository.GetAsync(x => x.CustomerId == id);
                _customerManageRepository.Remove(model);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                _unitOfWork.Rollback();
            }
        }

        public async Task<CustomerVM> Get(Guid id)
        {
            CustomerVM datavm = new CustomerVM();
            try
            {
                var data = await _customerRepository.GetAsync(x => x.Id == id);
                datavm = _mapper.Map<CustomerVM>(data);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
            return datavm;
        }

        public IEnumerable<CustomerVM> GetCustomerVMs()
        {
            List<CustomerVM> CustomerVMs = new List<CustomerVM>();
            var data = _customerRepository.GetAll();

            CustomerVMs = _mapper.ProjectTo<CustomerVM>(data).ToList();

            return CustomerVMs;
        }

        public async Task Update(CustomerVM Customer)
        {
            try
            {
                var data = _mapper.Map<Customer>(Customer);
                _customerRepository.Update(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
        }

        private async Task AddCustomerManage(Guid? UserId, Guid? CusId)
        {
            try
            {
                CustomerManage customerManage = new CustomerManage()
                {
                    CustomerId = CusId,
                    CustomerStatusId = 1,
                    DateAdded = DateTime.Now,
                    GroupCustomerId = 1,
                    StaffMKTId = UserId,
                    StaffSaleId = Guid.Empty
                };
                await _customerManageRepository.AddAsync(customerManage);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
        }

        public async Task UpdateSale(Guid saleId, List<string> cusLis)
        {
            try
            {
                foreach (var cus in cusLis)
                {
                    var cusSale = await _customerManageRepository.
                                        GetAsync(x => x.CustomerId == Guid.Parse(cus));
                    cusSale.StaffSaleId = saleId;
                    cusSale.CustomerStatusId = 2;
                }
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
            }
        }

        public async Task<ResponseData<CustomerSale>> GetAll(Pageding pageding)
        {
            try
            {
                ResponseData<CustomerSale> response = new ResponseData<CustomerSale>();

                var data = from cus in _customerRepository.GetAll()
                           join cusma in _customerManageRepository.GetAll()
                           on cus.Id equals cusma.CustomerId
                           join usemkt in _userManager.Users
                           on cusma.StaffMKTId equals usemkt.Id
                           join usesale in _userManager.Users
                           on cusma.StaffSaleId equals usesale.Id into ps_staffsale
                           from ps in ps_staffsale.DefaultIfEmpty()
                           join cusStatus in _customerStatusRepsitory.GetAll()
                           on cusma.CustomerStatusId equals cusStatus.Id
                           select new CustomerSale()
                           {
                               Id = cus.Id,
                               NameMKT = usemkt.FullName,
                               NameSale = ps.FullName,
                               PhoneNumber = cus.PhoneNumber,
                               StatusSale = cusStatus.Name,
                               CretedDate = cusma.DateAdded,
                               Status = cusStatus.Id

                           };
                if (!string.IsNullOrEmpty(pageding.KeyWord))
                {
                    data = data.Where(x => x.PhoneNumber.Contains(pageding.KeyWord)
                    || x.NameMKT.Contains(pageding.KeyWord) || x.NameSale.Contains(pageding.KeyWord)
                    );
                };
                if (pageding.StartDay != null && pageding.EndDay != null)
                {
                    //Xử ly thoi gian
                    pageding.EndDay = pageding.EndDay.Value.AddDays(1);
                    data = data.Where(x => x.CretedDate >= pageding.StartDay
                    && x.CretedDate <= pageding.EndDay);
                };
                if (pageding.StatusCustomer > 0)
                {
                    data = data.Where(x => x.Status == pageding.StatusCustomer);
                };
                int toltalpages = (int)Math.Ceiling((await data.CountAsync() * 1.0 / pageding.PageSize));
                data = data.OrderByDescending(x => x.Id)
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
                return new ResponseData<CustomerSale>();
            }
        }

        public async Task<ResponseData<CustomerSale>> GetAllPhone(PagedingMKT pageding)
        {
            try
            {
                ResponseData<CustomerSale> response = new ResponseData<CustomerSale>();
                var data = from cus in _customerRepository.GetAll()
                           join cusma in _customerManageRepository.GetAll()
                           on cus.Id equals cusma.CustomerId
                           join usemkt in _userManager.Users
                           on cusma.StaffMKTId equals usemkt.Id
                           join usesale in _userManager.Users
                           on cusma.StaffSaleId equals usesale.Id into ps_staffsale
                           from ps in ps_staffsale.DefaultIfEmpty()
                           join cusStatus in _customerStatusRepsitory.GetAll()
                           on cusma.CustomerStatusId equals cusStatus.Id
                           where cusma.StaffMKTId == pageding.UserId
                          // && cusma.StaffSaleId.Value.Equals(ConstPrameter.Guiddefault)
                           select new CustomerSale()
                           {
                               Id = cus.Id,
                               NameMKT = usemkt.FullName,
                               NameSale = ps.FullName,
                               PhoneNumber = cus.PhoneNumber,
                               StatusSale = cusStatus.Name,
                               CretedDate = cusma.DateAdded,
                               Status = cusStatus.Id
                           };
                if (!string.IsNullOrEmpty(pageding.KeyWord))
                {
                    data = data.Where(x => x.PhoneNumber.Contains(pageding.KeyWord) 
                    || x.NameMKT.Contains(pageding.KeyWord)
                    || x.NameSale.Contains(pageding.KeyWord)
                    );
                };
                if(pageding.StartDay !=null && pageding.EndDay != null)
                {
                    //Xử ly thoi gian
                    pageding.EndDay = pageding.EndDay.Value.AddDays(1);
                    data = data.Where(x=>x.CretedDate>= pageding.StartDay 
                    && x.CretedDate<= pageding.EndDay);
                }
                if (pageding.StatusCustomer > 0)
                {
                    data = data.Where(x => x.Status == pageding.StatusCustomer);
                }
                int toltalpages = (int)Math.Ceiling((await data.CountAsync() * 1.0 / pageding.PageSize));
                data = data.OrderByDescending(x => x.Id)
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
                return new ResponseData<CustomerSale>();
            }
        }

        public async Task UpdateSale(CustomerMKTVM customerVM)
        {
            try
            {
                var data = _mapper.Map<Customer>(customerVM);
                _customerRepository.Update(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
        }
        public async Task<ResponseData<CustomerSale>> GetOrder(PagedingMKT pageding)
        {
            try
            {
                ResponseData<CustomerSale> response = new ResponseData<CustomerSale>();

                var data = from cus in _customerRepository.GetAll()
                           join cusma in _customerManageRepository.GetAll()
                           on cus.Id equals cusma.CustomerId
                           join usemkt in _userManager.Users
                           on cusma.StaffMKTId equals usemkt.Id
                           join usesale in _userManager.Users
                           on cusma.StaffSaleId equals usesale.Id into ps_staffsale
                           from ps in ps_staffsale.DefaultIfEmpty()
                           join cusStatus in _customerStatusRepsitory.GetAll()
                           on cusma.CustomerStatusId equals cusStatus.Id
                           join maord in _manageOrdersRepository.GetAll()
                           on cus.Id equals maord.CustomerId into ps_ManaOrder
                           from psMan in ps_ManaOrder.DefaultIfEmpty()
                           join app in _appointmentScheduleRepository.GetAll()
                           on cus.Id equals app.CustomerId into ps_appSchedule
                           from psapp in ps_appSchedule.DefaultIfEmpty()

                           where cusma.StaffSaleId == pageding.UserId
                           select new CustomerSale()
                           {
                               Id = cus.Id,
                               NameMKT = usemkt.FullName,
                               NameSale = ps.FullName,
                               PhoneNumber = cus.PhoneNumber,
                               StatusSale = cusStatus.Name,
                               Status = cusStatus.Id,
                               IsActive = psapp.IsActive == null ? false : true,
                               IsOrderActive = psMan.IsOrderActive == null ? false : true,
                           };
                if (!string.IsNullOrEmpty(pageding.KeyWord))
                {
                    data = data.Where(x => x.PhoneNumber.Contains(pageding.KeyWord));
                };
                int toltalpages = (int)Math.Ceiling((await data.CountAsync() * 1.0 / pageding.PageSize));
                data = data.OrderByDescending(x => x.Id)
                            .Skip(pageding.PageSize * (pageding.PageNum - 1))
                            .Take(pageding.PageSize);

                var list = await data
                    .ToListAsync();

                response.TotalPage = toltalpages;
                response.PageIndex = pageding.PageNum;
                response.Items = list;
                return response;
            }
            catch
            {
                return new ResponseData<CustomerSale>();
            }
        }

        public async Task EditCustomerStatus(string id, int status)
        {
            try
            {
                var data = _customerManageRepository.Get(x => x.CustomerId == Guid.Parse(id));
                data.CustomerStatusId = status;
                _customerManageRepository.Update(data);

                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
        }

		public async Task<ResponseData<CustomerSale>> GetCustomerBom(PagedingMKT pageding)
		{
			try
			{
				ResponseData<CustomerSale> response = new ResponseData<CustomerSale>();

                var data = from cus in _customerRepository.GetAll()
                           join cusma in _customerManageRepository.GetAll()
                           on cus.Id equals cusma.CustomerId
                           join usemkt in _userManager.Users
                           on cusma.StaffMKTId equals usemkt.Id
                           join usesale in _userManager.Users
                           on cusma.StaffSaleId equals usesale.Id into ps_staffsale
                           from ps in ps_staffsale.DefaultIfEmpty()
                           join cusStatus in _customerStatusRepsitory.GetAll()
                           on cusma.CustomerStatusId equals cusStatus.Id
                           join manacus in _managementCancellationsRepository.GetAll()
                           on cusma.CustomerId equals manacus.CustomerId

                           where cusma.CustomerStatusId == ConstPrameter.CustomerStatusBom

						   select new CustomerSale()
						   {
							   Id = cus.Id,
                               NameCus = cus.Name,
                               EmailCus = cus.Email,
							   NameMKT = usemkt.FullName,
							   NameSale = ps.FullName,
							   PhoneNumber = cus.PhoneNumber,
							   StatusSale = cusStatus.Name,
                               DateBom = manacus.DeleteDate,
                               Note = manacus.Note
						   };
				if (!string.IsNullOrEmpty(pageding.KeyWord))
				{
					data = data.Where(x => x.PhoneNumber.Contains(pageding.KeyWord));
				};
				int toltalpages = (int)Math.Ceiling((await data.CountAsync() * 1.0 / pageding.PageSize));
				data = data.OrderByDescending(x => x.Id)
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
				return new ResponseData<CustomerSale>();
			}
		}
	}
}
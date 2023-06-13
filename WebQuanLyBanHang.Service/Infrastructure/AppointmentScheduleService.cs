using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Repository.Interface;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Service.Infrastructure
{
	public class AppointmentScheduleService : IAppointmentScheduleService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly ICustomerRepository _customerRepository;
		private readonly IAppointmentScheduleRepository _appointmentScheduleRepository;
		private readonly ICustomerManageRepository _customerManagesRepository;

		public AppointmentScheduleService(IUnitOfWork unitOfWork,
			IMapper mapper,
			ICustomerRepository customerRepository,
			IAppointmentScheduleRepository appointmentScheduleRepository,
			ICustomerManageRepository customerManageRepository)
		{
			_appointmentScheduleRepository = appointmentScheduleRepository;
			_customerRepository = customerRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_customerManagesRepository = customerManageRepository;
		}

		public async Task Add(AppointmentScheduleVM appointmentSchedule)
		{
			try
			{
				var data = _mapper.Map<AppointmentSchedule>(appointmentSchedule);
				await _appointmentScheduleRepository.AddAsync(data);
				_unitOfWork.Commit();
			}
			catch (Exception ex)
			{
				_unitOfWork.Rollback();
			}
		}

		public async Task Delete(int id)
		{
			try
			{
				var data = await _appointmentScheduleRepository.GetAsync(x => x.Id == id);
				_appointmentScheduleRepository.Remove(data);
				await _unitOfWork.CommitAsync();
			}
			catch
			{
				_unitOfWork.Rollback();
			}
		}

		public async Task<AppointmentScheduleVM> Get(int id)
		{
			AppointmentScheduleVM datavm = new AppointmentScheduleVM();
			try
			{
				var data = await _appointmentScheduleRepository.GetAsync(x => x.Id == id);
				datavm = _mapper.Map<AppointmentScheduleVM>(data);
				datavm.DateAppointments = datavm.AppointmentDate.Value.ToString("dd/MM/yyyy");

            }
			catch (Exception ex)
			{
				_unitOfWork.Rollback();
			}
			return datavm;
		}

		public async Task<ResponseData<AppointmentScheduleView>> GetAll(Pageding pageding)
		{
			ResponseData<AppointmentScheduleView> response = new ResponseData<AppointmentScheduleView>();
			try
			{
				var data = from app in _appointmentScheduleRepository.GetAll()
						   join cust in _customerRepository.GetAll()
						   on app.CustomerId equals cust.Id
						   join cusmana in _customerManagesRepository.GetAll()
						   on app.CustomerId equals cusmana.CustomerId
						   // where cu.Id == id
						   select new AppointmentScheduleView
						   {
							   DateAppointment = app.AppointmentDate,
							   Id = app.Id,
							   Name = cust.Name,
							   Note = app.Note,
							   PhoneNumber = cust.PhoneNumber
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
				return new ResponseData<AppointmentScheduleView>();
			}
		}

		public async Task Update(AppointmentScheduleVM appointmentSchedule)
		{
			try
			{
				var data = _mapper.Map<AppointmentScheduleVM, AppointmentSchedule>(appointmentSchedule);

				_appointmentScheduleRepository.Update(data);

				await _unitOfWork.CommitAsync();
			}
			catch
			{
				_unitOfWork.Rollback();
			}
		}
	}
}
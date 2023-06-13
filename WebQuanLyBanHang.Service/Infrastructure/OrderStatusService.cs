using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Repository.Interface;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Service.Infrastructure
{
    public class OrderStatusService : IOrderStatusService
    {
        public IUnitOfWork _unitOfWork;
        public IMapper _mapper;
        public IOrderStatusRepository _orderStatusRepository;

        public OrderStatusService(IUnitOfWork unitOfWork,
            IOrderStatusRepository orderStatusRepository, IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _orderStatusRepository = orderStatusRepository;
            _mapper = mapper;
        }

        public async Task Add(OrderStatusVM orderStatus)
        {
            try
            {
                var data = _mapper.Map<OrderStatus>(orderStatus);
                await _orderStatusRepository.AddAsync(data);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
        }

        public async Task<bool> CheckData(string word)
        {
            return await _orderStatusRepository.CheckWord(x => x.Name == word);
        }

        public async Task Delete(int id)
        {
            try
            {
                var data = await _orderStatusRepository.GetAsync(x => x.Id == id);
                _orderStatusRepository.Remove(data);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                _unitOfWork.Rollback();
            }
        }

        public async Task<OrderStatusVM> Get(int id)
        {
            OrderStatusVM datavm = new OrderStatusVM();
            try
            {
                var data = await _orderStatusRepository.GetAsync(x => x.Id == id);
                datavm = _mapper.Map<OrderStatusVM>(data);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
            return datavm;
        }

        public async Task<ResponseData<OrderStatusVM>> GetAll(Pageding pageding)
        {
            ResponseData<OrderStatusVM> response = new ResponseData<OrderStatusVM>();

            var data = _orderStatusRepository.GetAll();
            if (!string.IsNullOrEmpty(pageding.KeyWord))
            {
                data = data.Where(x => x.Name.Contains(pageding.KeyWord));
            };
            int toltalpages = (int)Math.Ceiling((await data.CountAsync() * 1.0 / pageding.PageSize));
            data = data.OrderByDescending(x => x.Id)
                        .Skip(pageding.PageSize * (pageding.PageNum - 1))
                        .Take(pageding.PageSize);

            var list = await _mapper.ProjectTo<OrderStatusVM>(data).ToListAsync();

            response.TotalPage = toltalpages;
            response.PageIndex = pageding.PageNum;
            response.Items = list;

            return response;
        }

        public async Task<List<OrderStatusVM>> Gets()
        {
            return await _mapper.ProjectTo<OrderStatusVM>(
                _orderStatusRepository.GetAll()).ToListAsync();
        }

        public async Task Update(OrderStatusVM orderStatus)
        {
            try
            {
                var data = _mapper.Map<OrderStatus>(orderStatus);
                _orderStatusRepository.Update(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
        }

        
    }
}
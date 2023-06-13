using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Repository.Interface;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Service.Infrastructure
{
    public class OrderSourceService : IOrderSourceService
    {
        public IUnitOfWork _unitOfWork;
        public IMapper _mapper;
        public IOrderSourceRepository _orderSourceRepository;
        public OrderSourceService(IUnitOfWork unitOfWork,
            IOrderSourceRepository orderSourceRepository, IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _orderSourceRepository = orderSourceRepository;
            _mapper = mapper;
        }
        public async Task Add(OrderSourceVM OrderSource)
        {
            try
            {
                var data = _mapper.Map<OrderSource>(OrderSource);
                await _orderSourceRepository.AddAsync(data);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
        }

        public async Task<bool> CheckData(string word)
        {
            return await _orderSourceRepository.CheckWord(x => x.Name == word);
        }

        public async Task Delete(int id)
        {
            try
            {
                var data = await _orderSourceRepository.GetAsync(x => x.Id == id);
                _orderSourceRepository.Remove(data);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                _unitOfWork.Rollback();
            }
        }

        public async Task<OrderSourceVM> Get(int id)
        {
            OrderSourceVM datavm = new OrderSourceVM();
            try
            {
                var data = await _orderSourceRepository.GetAsync(x => x.Id == id);
                datavm = _mapper.Map<OrderSourceVM>(data);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
            return datavm;
        }
        public async Task<ResponseData<OrderSourceVM>> GetAll(Pageding pageding)
        {
            ResponseData<OrderSourceVM> response = new ResponseData<OrderSourceVM>();

            var data = _orderSourceRepository.GetAll();
            if (!string.IsNullOrEmpty(pageding.KeyWord))
            {
                data = data.Where(x => x.Name.Contains(pageding.KeyWord));
            };
            int toltalpages = (int)Math.Ceiling((await data.CountAsync() * 1.0 / pageding.PageSize));
            data = data.OrderByDescending(x => x.Id)
                        .Skip(pageding.PageSize * (pageding.PageNum - 1))
                        .Take(pageding.PageSize);

            var list = await _mapper.ProjectTo<OrderSourceVM>(data).ToListAsync();

            response.TotalPage = toltalpages;
            response.PageIndex = pageding.PageNum;
            response.Items = list;

            return response;
        }

        public async Task<List<OrderSourceVM>> Gets()
        {
           return await _mapper.ProjectTo<OrderSourceVM>(_orderSourceRepository.GetAll()).ToListAsync();
        }

        public async Task Update(OrderSourceVM OrderSource)
        {
            try
            {
                var data = _mapper.Map<OrderSource>(OrderSource);
                _orderSourceRepository.Update(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }

        }
    }
}

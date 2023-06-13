using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Repository.Infrastructure;
using WebQuanLyBanHang.Repository.Interface;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Service.Infrastructure
{

    public class MethodDeliveryService : IMethodDeliveryService
    {
        public IUnitOfWork _unitOfWork;
        public IMapper _mapper;
        public IMethodDeliveryRepository _methodDeliveryRepository;
        public MethodDeliveryService(IUnitOfWork unitOfWork,
            IMethodDeliveryRepository methodDeliveryRepository, IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _methodDeliveryRepository = methodDeliveryRepository;
            _mapper = mapper;
        }
        public async Task Add(MethodDeliveryVM methodDelivery)
        {
            try
            {
                var data = _mapper.Map<MethodDelivery>(methodDelivery);
                await _methodDeliveryRepository.AddAsync(data);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
        }

        public async Task<bool> CheckData(string word)
        {
            return await _methodDeliveryRepository.CheckWord(x => x.Name == word);
        }

        public async Task Delete(int id)
        {
            try
            {
                var data = await _methodDeliveryRepository.GetAsync(x => x.Id == id);
                _methodDeliveryRepository.Remove(data);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                _unitOfWork.Rollback();
            }
        }

        public async Task<MethodDeliveryVM> Get(int id)
        {
            MethodDeliveryVM datavm = new MethodDeliveryVM();
            try
            {
                var data = await _methodDeliveryRepository.GetAsync(x => x.Id == id);
                datavm = _mapper.Map<MethodDeliveryVM>(data);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
            return datavm;
        }

        public async Task<ResponseData<MethodDeliveryVM>> GetAll(Pageding pageding)
        {
            ResponseData<MethodDeliveryVM> response = new ResponseData<MethodDeliveryVM>();

            var data = _methodDeliveryRepository.GetAll();
            if (!string.IsNullOrEmpty(pageding.KeyWord))
            {
                data = data.Where(x => x.Name.Contains(pageding.KeyWord));
            };
            int toltalpages = (int)Math.Ceiling((await data.CountAsync() * 1.0 / pageding.PageSize));
            data = data.OrderByDescending(x => x.Id)
                        .Skip(pageding.PageSize * (pageding.PageNum - 1))
                        .Take(pageding.PageSize);

            var list = await _mapper.ProjectTo<MethodDeliveryVM>(data).ToListAsync();

            response.TotalPage = toltalpages;
            response.PageIndex = pageding.PageNum;
            response.Items = list;

            return response;
        }

        public async Task<List<MethodDeliveryVM>> Gets()
        {
            return await _mapper.ProjectTo<MethodDeliveryVM>
                (_methodDeliveryRepository.GetAll()).ToListAsync();
        }

        public async Task Update(MethodDeliveryVM  methodDelivery)
        {
            try
            {
                var data = _mapper.Map<MethodDelivery>(methodDelivery);
                _methodDeliveryRepository.Update(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
        }
    }
}

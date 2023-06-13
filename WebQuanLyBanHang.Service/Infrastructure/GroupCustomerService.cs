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
    public class GroupCustomerService : IGroupCustomerService
    {
        public IUnitOfWork _unitOfWork;
        public IMapper _mapper;
        public IGroupCustomerRepository _groupCustomerRepository;
        public GroupCustomerService(IUnitOfWork unitOfWork,
            IGroupCustomerRepository  groupCustomerRepository, IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _groupCustomerRepository = groupCustomerRepository;
            _mapper = mapper;
        }
        public async Task Add(GroupCustomerVM groupCustomer)
        {
            try
            {
                var data = _mapper.Map<GroupCustomer>(groupCustomer);
                await _groupCustomerRepository.AddAsync(data);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
        }

        public async Task<bool> CheckData(string word)
        {
            return await _groupCustomerRepository.CheckWord(x => x.Name == word);
        }

        public async Task Delete(int id)
        {
            try
            {
                var data = await _groupCustomerRepository.GetAsync(x => x.Id == id);
                _groupCustomerRepository.Remove(data);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                _unitOfWork.Rollback();
            }
        }

        public async Task<GroupCustomerVM> Get(int id)
        {
            GroupCustomerVM datavm = new GroupCustomerVM();
            try
            {
                var data = await _groupCustomerRepository.GetAsync(x => x.Id == id);
                datavm = _mapper.Map<GroupCustomerVM>(data);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
            return datavm;
        }
        public async Task<ResponseData<GroupCustomerVM>> GetAll(Pageding pageding)
        {
            ResponseData<GroupCustomerVM> response = new ResponseData<GroupCustomerVM>();

            var data = _groupCustomerRepository.GetAll();
            if (!string.IsNullOrEmpty(pageding.KeyWord))
            {
                data = data.Where(x => x.Name.Contains(pageding.KeyWord));
            };
            int toltalpages = (int)Math.Ceiling((await data.CountAsync() * 1.0 / pageding.PageSize));
            data = data.OrderByDescending(x => x.Id)
                        .Skip(pageding.PageSize * (pageding.PageNum - 1))
                        .Take(pageding.PageSize);

            var list = await _mapper.ProjectTo<GroupCustomerVM>(data).ToListAsync();

            response.TotalPage = toltalpages;
            response.PageIndex = pageding.PageNum;
            response.Items = list;

            return response;
        }

        public async Task<List<GroupCustomerVM>> Gets()
        {
           return await _mapper.ProjectTo<GroupCustomerVM>(
               _groupCustomerRepository.GetAll()).ToListAsync();
        }

        public async Task Update(GroupCustomerVM OrderSource)
        {
            try
            {
                var data = _mapper.Map<GroupCustomer>(OrderSource);
                _groupCustomerRepository.Update(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }

        }
    }
}

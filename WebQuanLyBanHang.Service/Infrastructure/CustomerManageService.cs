using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Repository.Interface;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Service.Infrastructure
{
    public class CustomerManageService : ICustomerManageService
    {
        public IUnitOfWork _unitOfWork;
        public IMapper _mapper;
        public ICustomerManageRepository  _customerManageRepository;
        public CustomerManageService(IUnitOfWork unitOfWork,
            ICustomerManageRepository customerManageRepository, IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _customerManageRepository = customerManageRepository;
            _mapper = mapper;
        }
        public async Task Add(CustomerManageVM customerManage)
        {
            try
            {
                var data = _mapper.Map<CustomerManage>(customerManage);
                await _customerManageRepository.AddAsync(data);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
        }
    }
}

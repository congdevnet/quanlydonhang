using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyBanHang.Repository.Infrastructure;
using WebQuanLyBanHang.Repository.Interface;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Service.Infrastructure
{
    public class StatusProductService : IStatusProductService
    {
        public readonly IStatusProductRepository _statusProductRepository;
        public IUnitOfWork _unitOfWork;
        public IMapper _mapper;
        
        public StatusProductService(IUnitOfWork unitOfWork,
            IStatusProductRepository statusProductRepository, IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            this._statusProductRepository = statusProductRepository;
            _mapper = mapper;
        }
        public IEnumerable<StatusProductVM> Get()
        {

            List<StatusProductVM> classifyProductVMs = new List<StatusProductVM>();
            var data = _statusProductRepository.GetAll();

            classifyProductVMs = _mapper.ProjectTo<StatusProductVM>(data).ToList();

            return classifyProductVMs;
        }
    }
}

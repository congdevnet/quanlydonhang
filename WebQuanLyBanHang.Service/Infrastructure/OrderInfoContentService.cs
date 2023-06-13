using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyBanHang.Repository.Infrastructure;
using WebQuanLyBanHang.Repository.Interface;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Service.Infrastructure
{
    public class OrderInfoContentService : IOrderInfoContentService
    {
        public IUnitOfWork _unitOfWork;
        public IMapper _mapper;
        public IOrderInfoContentRepository  _orderInfoContentRepository;
        public OrderInfoContentService(IUnitOfWork unitOfWork,
            IOrderInfoContentRepository orderInfoContentRepository, IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _orderInfoContentRepository = orderInfoContentRepository;
            _mapper = mapper;
        }
        public Task Add(OrderInfoContentVM orderInfoContent)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckData(string word)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public  Task<OrderInfoContentVM> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseData<OrderInfoContentVM>> GetAll(Pageding pageding)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderInfoContentVM>> Gets()
        {
            return await _mapper.ProjectTo<OrderInfoContentVM>
              (_orderInfoContentRepository.GetAll()).ToListAsync();
        }

        public Task Update(OrderInfoContentVM orderInfoContent)
        {
            throw new NotImplementedException();
        }
    }
}

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
    public class SingleTypeService : ISingleTypeService
    {
        public IUnitOfWork _unitOfWork;
        public IMapper _mapper;
        public ISingleTypeRepository _singleTypeRepository;
        public SingleTypeService(IUnitOfWork unitOfWork,
            ISingleTypeRepository singleTypeRepository, IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _singleTypeRepository = singleTypeRepository;
            _mapper = mapper;
        }
        public Task Add(SingleTypeVM singleType)
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

        public Task<SingleTypeVM> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseData<SingleTypeVM>> GetAll(Pageding pageding)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SingleTypeVM>> Gets()
        {
            return await _mapper.ProjectTo<SingleTypeVM>(
                _singleTypeRepository.GetAll()).ToListAsync();
        }

        public Task Update(SingleTypeVM singleType)
        {
            throw new NotImplementedException();
        }
    }
}

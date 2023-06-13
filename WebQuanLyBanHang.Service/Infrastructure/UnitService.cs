
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities.ViewModel;
using WebQuanLyBanHang.Utilities;
using AutoMapper;
using WebQuanLyBanHang.Repository.Interface;
using WebQuanLyBanHang.Data.Entity;
using Microsoft.EntityFrameworkCore;
using WebQuanLyBanHang.Repository.Infrastructure;

namespace WebQuanLyBanHang.Service.Infrastructure
{
    public class UnitService: IUnitService
    {
        public IUnitOfWork _unitOfWork;
        public IMapper _mapper;
        public IUnitRepository _unitRepository;
        public UnitService(IUnitOfWork unitOfWork,
            IUnitRepository  unitRepository, IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _unitRepository = unitRepository;
            _mapper = mapper;
        }
        public async Task Add(UnitVM unitVM)
        {
            try
            {
                var data = _mapper.Map<Unit>(unitVM);
                await _unitRepository.AddAsync(data);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
        }

        public async Task<bool> CheckData(string word)
        {
            return await _unitRepository.CheckWord(x => x.Name == word);
        }

        public async Task Delete(int id)
        {
            try
            {
                var data = await _unitRepository.GetAsync(x => x.Id == id);
                _unitRepository.Remove(data);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                _unitOfWork.Rollback();
            }
        }

        public async Task<UnitVM> Get(int id)
        {
            UnitVM datavm = new UnitVM();
            try
            {
                var data = await _unitRepository.GetAsync(x => x.Id == id);
                datavm = _mapper.Map<UnitVM>(data);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
            return datavm;
        }
        public async Task<ResponseData<UnitVM>> GetAll(Pageding pageding)
        {
            ResponseData<UnitVM> response = new ResponseData<UnitVM>();

            var data = _unitRepository.GetAll();
            if (!string.IsNullOrEmpty(pageding.KeyWord))
            {
                data = data.Where(x => x.Name.Contains(pageding.KeyWord));
            };
            int toltalpages = (int)Math.Ceiling((await data.CountAsync() * 1.0 / pageding.PageSize));
            data = data.OrderByDescending(x => x.Id)
                        .Skip(pageding.PageSize * (pageding.PageNum - 1))
                        .Take(pageding.PageSize);

            var list = await _mapper.ProjectTo<UnitVM>(data).ToListAsync();

            response.TotalPage = toltalpages;
            response.PageIndex = pageding.PageNum;
            response.Items = list;

            return response;
        }

        public  IEnumerable<UnitVM> GetUnitVMs()
        {
            List<UnitVM> unitVMs = new List<UnitVM>();
            var data = _unitRepository.GetAll();

            unitVMs = _mapper.ProjectTo<UnitVM>(data).ToList();

            return unitVMs;
        }

        public async Task Update(UnitVM unitVM)
        {
            try
            {
                var data = _mapper.Map<Unit>(unitVM);
                _unitRepository.Update(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }

        }
    }
}

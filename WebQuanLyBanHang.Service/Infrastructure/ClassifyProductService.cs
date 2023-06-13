using AutoMapper;
using WebQuanLyBanHang.Repository.Interface;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities.ViewModel;
using WebQuanLyBanHang.Utilities;
using WebQuanLyBanHang.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace WebQuanLyBanHang.Service.Infrastructure
{
    public class ClassifyProductService: IClassifyProductService
    {
        public IUnitOfWork _unitOfWork;
        public IMapper _mapper;
        public IClassifyProductRepository _classifyProductRepository;
        public ClassifyProductService(IUnitOfWork unitOfWork,
            IClassifyProductRepository ClassifyProductRepository, IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _classifyProductRepository = ClassifyProductRepository;
            _mapper = mapper;
        }
        public async Task Add(ClassifyProductVM classifyProduct)
        {
            try
            {
                var data = _mapper.Map<ClassifyProduct>(classifyProduct);
                await _classifyProductRepository.AddAsync(data);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
        }

        public async Task<bool> CheckData(string word)
        {
            return await _classifyProductRepository.CheckWord(x => x.Name == word);
        }

        public async Task Delete(int id)
        {
            try
            {
                var data = await _classifyProductRepository.GetAsync(x => x.Id == id);
                _classifyProductRepository.Remove(data);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                _unitOfWork.Rollback();
            }
        }

        public async Task<ClassifyProductVM> Get(int id)
        {
            ClassifyProductVM datavm = new ClassifyProductVM();
            try
            {
                var data = await _classifyProductRepository.GetAsync(x => x.Id == id);
                datavm = _mapper.Map<ClassifyProductVM>(data);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
            return datavm;
        }
        public async Task<ResponseData<ClassifyProductVM>> GetAll(Pageding pageding)
        {
            ResponseData<ClassifyProductVM> response = new ResponseData<ClassifyProductVM>();

            var data = _classifyProductRepository.GetAll();
            if (!string.IsNullOrEmpty(pageding.KeyWord))
            {
                data = data.Where(x => x.Name.Contains(pageding.KeyWord));
            };
            int toltalpages = (int)Math.Ceiling((await data.CountAsync() * 1.0 / pageding.PageSize));
            data = data.OrderByDescending(x => x.Id)
                        .Skip(pageding.PageSize * (pageding.PageNum - 1))
                        .Take(pageding.PageSize);

            var list = await _mapper.ProjectTo<ClassifyProductVM>(data).ToListAsync();

            response.TotalPage = toltalpages;
            response.PageIndex = pageding.PageNum;
            response.Items = list;

            return response;
        }

        public IEnumerable<ClassifyProductVM> GetClassifyProductVMs()
        {
            List<ClassifyProductVM> classifyProductVMs  = new List<ClassifyProductVM>();
            var data =   _classifyProductRepository.GetAll();

            classifyProductVMs =  _mapper.ProjectTo<ClassifyProductVM>(data).ToList();

            return classifyProductVMs;
        }

        public async Task Update(ClassifyProductVM ClassifyProduct)
        {
            try
            {
                var data = _mapper.Map<ClassifyProduct>(ClassifyProduct);
                _classifyProductRepository.Update(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }

        }
    }
}

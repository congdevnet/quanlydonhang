using AutoMapper;
using WebQuanLyBanHang.Repository.Interface;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities.ViewModel;
using WebQuanLyBanHang.Utilities;
using Microsoft.EntityFrameworkCore;
using WebQuanLyBanHang.Data.Entity;
using System.Linq.Expressions;

namespace WebQuanLyBanHang.Service.Infrastructure
{
    public class ProductService: IProductService
    {
        public IUnitOfWork _unitOfWork;
        public IMapper _mapper;
        public IProductRepository _productRepository;
        public ProductService(IUnitOfWork unitOfWork,
            IProductRepository productRepository, IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task Add(ProductVM productVM)
        {
            try
            {
                var data = _mapper.Map<Product>(productVM);
                await _productRepository.AddAsync(data);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
        }

        public async Task<bool> CheckData(string word)
        {
            return await _productRepository.CheckWord(x => x.ProductName == word);
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var data = await _productRepository.GetAsync(x => x.Id == id);
                _productRepository.Remove(data);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                _unitOfWork.Rollback();
            }
        }

        public async Task<ProductVM> Get(Guid id)
        {
            ProductVM datavm = new ProductVM();
            try
            {
                var data = await _productRepository.GetAsync(x => x.Id == id);
                datavm = _mapper.Map<ProductVM>(data);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
            return datavm;
        }
        public async Task<ResponseData<ProductVM>> GetAll(Pageding pageding)
        {
            ResponseData<ProductVM> response = new ResponseData<ProductVM>();

            var data = _productRepository.GetAll();
            if (!string.IsNullOrEmpty(pageding.KeyWord))
            {
                data = data.Where(x => x.ProductName.Contains(pageding.KeyWord));
            };
            int toltalpages = (int)Math.Ceiling((await data.CountAsync() * 1.0 / pageding.PageSize));
            data = data.OrderByDescending(x => x.Id)
                        .Skip(pageding.PageSize * (pageding.PageNum - 1))
                        .Take(pageding.PageSize);

            var list = await _mapper.ProjectTo<ProductVM>(data).ToListAsync();

            response.TotalPage = toltalpages;
            response.PageIndex = pageding.PageNum;
            response.Items = list;

            return response;
        }

        public async Task<List<ProductVM>> Gets(Expression<Func<Product, bool>> expression)
        {
            List<ProductVM> datavm = new List<ProductVM>();
            try
            {
                var data =  _productRepository.GetAll(expression);
                datavm = await _mapper.ProjectTo<ProductVM>(data).ToListAsync();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
            return datavm;
        }

        public async Task Update(ProductVM productVM)
        {
            try
            {
                var data = _mapper.Map<Product>(productVM);
                _productRepository.Update(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }

        }
    }
}

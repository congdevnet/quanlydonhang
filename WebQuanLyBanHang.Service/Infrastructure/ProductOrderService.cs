using AutoMapper;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Repository.Interface;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Service.Infrastructure
{
    public class ProductOrderService : IProductOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductOrderRepository _productOrderRepository;

        public ProductOrderService(IUnitOfWork unitOfWork, IMapper mapper,
            IProductOrderRepository productOrderRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productOrderRepository = productOrderRepository;
        }

        public async Task Add(ProductOrderVM productOrderVM)
        {
            try
            {
                // Kiểm tra sản phẩm đã có chưa //
                bool check = await _productOrderRepository.CheckWord(x => x.OrderId == productOrderVM.OrderId
                && x.ProductId == productOrderVM.ProductId);
                /// Tổn tại cập nhật thêm sản phẩm //
                if (check)
                {
                    var model = _productOrderRepository.Get(x => x.OrderId == productOrderVM.OrderId
                        && x.ProductId == productOrderVM.ProductId);

                    model.Quantity += productOrderVM.Quantity;

                    _productOrderRepository.Update(model);
                }
                else
                {  // Thêm mới sản phẩm
                    var data = _mapper.Map<ProductOrder>(productOrderVM);
                    _productOrderRepository.Add(data);
                }
                //
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                _unitOfWork.Rollback();
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var data = await _productOrderRepository.GetAsync(x => x.Id == id);
                _productOrderRepository.Remove(data);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                _unitOfWork.Rollback();
            }
        }
    }
}
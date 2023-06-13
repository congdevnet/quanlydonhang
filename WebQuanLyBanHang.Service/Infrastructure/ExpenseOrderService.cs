using AutoMapper;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Repository.Infrastructure;
using WebQuanLyBanHang.Repository.Interface;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Service.Infrastructure
{
    public class ExpenseOrderService : IExpenseOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IExpenseOrderRepository _expenseOrderRepository;
        public ExpenseOrderService(IUnitOfWork unitOfWork, 
            IMapper mapper,  IExpenseOrderRepository expenseOrderRepository  )
        {
            _expenseOrderRepository = expenseOrderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;   
        }
        public async Task Update(ExpenseOrderVM expenseOrderVM)
        {
            try
            {
                var data = _mapper.Map<ExpenseOrderVM, ExpenseOrder>(expenseOrderVM);

                _expenseOrderRepository.Update(data);

                await _unitOfWork.CommitAsync();
            }
            catch
            {
                _unitOfWork.Rollback();
            }
        }
    }
}
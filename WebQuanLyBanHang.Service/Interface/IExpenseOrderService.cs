using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Service.Interface
{
    public interface IExpenseOrderService
    {
        public Task Update(ExpenseOrderVM expenseOrderVM);
    }
}
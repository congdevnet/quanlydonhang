using Microsoft.AspNetCore.Mvc;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Controllers
{
    public class ExpenseOrdersController : BaseController
    {
        private readonly IExpenseOrderService _expenseOrderService;
        public ExpenseOrdersController(IExpenseOrderService expenseOrderService)
        {
            _expenseOrderService = expenseOrderService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromBody]ExpenseOrderVM expenseOrderVM)
        {
            await _expenseOrderService.Update(expenseOrderVM);
            return Ok();
        }

    }
}

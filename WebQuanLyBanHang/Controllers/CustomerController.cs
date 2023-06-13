using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebQuanLyBanHang.Models;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerStatusService _customerStatusService;

        public CustomerController(ICustomerService customerService,
            ICustomerStatusService customerStatusService)
        {
            _customerService = customerService;
            _customerStatusService = customerStatusService;
        }
        [HttpGet]
        [Route("danh-sach-len-don")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Table(Pageding pageding)
        {
            GetSelectList();
            PagedingMKT pagedingMKT = new PagedingMKT()
            {
                KeyWord = pageding.KeyWord,
                PageNum = pageding.PageNum,
                PageSize = pageding.PageSize,
                UserId = Guid.Parse(HttpContext.Request.Cookies[ConstSession.UserId]),
            };
            var data = await _customerService.GetOrder(pagedingMKT);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> ChangStatus(string customerId, int customerStatusId)
        {
            await _customerService.EditCustomerStatus(customerId, customerStatusId);
            return Ok();
        }
        private void GetSelectList(object? selectedCus = null)
        {
            ViewBag.CustomerStatus = new SelectList(_customerStatusService.GetCustomerStatus(),
                "Id", "Name", selectedCus);
        }
    }
}
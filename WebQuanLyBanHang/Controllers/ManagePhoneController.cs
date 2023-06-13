using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebQuanLyBanHang.Models;
using WebQuanLyBanHang.Service.Infrastructure;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Controllers
{
    public class ManagePhoneController : BaseController
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerStatusService _customerStatusService;

        public ManagePhoneController(
            ICustomerService customerService, 
            ICustomerStatusService customerStatusService )
        {
            _customerService = customerService;
            _customerStatusService = customerStatusService;
        }

        [Route("them-so-dien-thoai")]
        public IActionResult Index()
        {
            SelectCustomerStatus();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Table(Pageding pageding)
        {
            PagedingMKT pagedingMKT = new PagedingMKT()
            {
                KeyWord = pageding.KeyWord,
                PageNum = pageding.PageNum,
                PageSize = pageding.PageSize,
                StartDay = pageding.StartDay,
                EndDay = pageding.EndDay,
                StatusCustomer = pageding.StatusCustomer,
                UserId = Guid.Parse(HttpContext.Request.Cookies[ConstSession.UserId]),
            };
            var data = await _customerService.GetAllPhone(pagedingMKT);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CustomerMKTVM model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            if (model.Id == ConstPrameter.Guiddefault)
            {
                model.UserId = Guid.Parse(HttpContext.Request.Cookies[ConstSession.UserId]);
                await _customerService.Add(model);
                return Ok(StatusCode(200));
            }
            else
            {
                await _customerService.UpdateSale(model);
                return Ok(StatusCode(201));
            }
            ;
        }

        [HttpGet]
        public async Task<IActionResult> GetModel(Guid id)
        {
            var data = await _customerService.Get(id);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> CheckData(string keyword)
        {
            var data = await _customerService.CheckData(keyword);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _customerService.Delete(id);
            return Ok();
        }
        private void SelectCustomerStatus()
        {
            ViewBag.SelectCus = new SelectList(_customerStatusService.GetCustomerStatus(), "Id", "Name");
        }
    }
}
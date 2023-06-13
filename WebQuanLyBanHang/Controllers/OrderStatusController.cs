using Microsoft.AspNetCore.Mvc;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Service.Infrastructure;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Controllers
{
    public class OrderStatusController : BaseController
	{
        private readonly IOrderStatusService orderStatusService;
        public OrderStatusController(IOrderStatusService _orderStatusService)
        {
            orderStatusService = _orderStatusService;
        }
        [HttpGet]
        [Route("trang-thai-don-hang")]
        public  IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Table(Pageding pageding) 
        {
            var data = await orderStatusService.GetAll(pageding);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] OrderStatusVM model)
        {
            /// Thêm mới khi id = 0
            if (model.Id < 1)
            {
                await orderStatusService.Add(model);
            }
            else
            {
                await orderStatusService.Update(model);
            }

            return Ok(model.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetModel(int id)
        {
            var data =  await orderStatusService.Get(id);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> CheckData(string keyword)
        {
            var data = await orderStatusService.CheckData(keyword);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await orderStatusService.Delete(id);
            return Ok();
        }
    }
}

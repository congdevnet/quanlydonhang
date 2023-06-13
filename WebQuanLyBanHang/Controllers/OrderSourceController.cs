using Microsoft.AspNetCore.Mvc;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities.ViewModel;
using WebQuanLyBanHang.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace WebQuanLyBanHang.Controllers
{
	public class OrderSourceController : BaseController
	{
        private readonly IOrderSourceService _orderSourceService;
        public OrderSourceController(IOrderSourceService orderSourceService)
        {
            _orderSourceService = orderSourceService;
        }
        [HttpGet]
        [Route("nguon-hang")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Table(Pageding pageding)
        {
            var data = await _orderSourceService.GetAll(pageding);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] OrderSourceVM model)
        {
            /// Thêm mới khi id = 0
            if (model.Id < 1)
            {
                await _orderSourceService.Add(model);
            }
            else
            {
                await _orderSourceService.Update(model);
            }

            return Ok(model.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetModel(int id)
        {
            var data = await _orderSourceService.Get(id);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> CheckData(string keyword)
        {
            var data = await _orderSourceService.CheckData(keyword);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderSourceService.Delete(id);
            return Ok();
        }
    }
}

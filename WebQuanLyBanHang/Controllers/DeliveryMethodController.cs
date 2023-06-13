using Microsoft.AspNetCore.Mvc;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities.ViewModel;
using WebQuanLyBanHang.Utilities;

namespace WebQuanLyBanHang.Controllers
{
    public class DeliveryMethodController : BaseController
	{
        private readonly IMethodDeliveryService _methodDeliveryService;
        public DeliveryMethodController(IMethodDeliveryService methodDeliveryService)
        {
            _methodDeliveryService = methodDeliveryService;
        }
        [HttpGet]
        [Route("hinh-thuc-giao-hang")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Table(Pageding pageding)
        {
            var data = await _methodDeliveryService.GetAll(pageding);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MethodDeliveryVM model)
        {
            /// Thêm mới khi id = 0
            if (model.Id < 1)
            {
                await _methodDeliveryService.Add(model);
            }
            else
            {
                await _methodDeliveryService.Update(model);
            }

            return Ok(model.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetModel(int id)
        {
            var data = await _methodDeliveryService.Get(id);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> CheckData(string keyword)
        {
            var data = await _methodDeliveryService.CheckData(keyword);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _methodDeliveryService.Delete(id);
            return Ok();
        }
    }
}

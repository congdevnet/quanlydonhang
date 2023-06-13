using Microsoft.AspNetCore.Mvc;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Controllers
{
    public class ProductOrdersController : BaseController
    {
        private readonly IProductOrderService _productOrderService;
        public ProductOrdersController(IProductOrderService productOrderService)
        {
            _productOrderService = productOrderService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductOrderVM productOrder)
        {
            await _productOrderService.Add(productOrder);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            await _productOrderService.Delete(Guid.Parse(id));
            return Ok();
        }


    }
}

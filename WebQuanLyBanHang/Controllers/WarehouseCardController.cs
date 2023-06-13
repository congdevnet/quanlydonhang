using Microsoft.AspNetCore.Mvc;

namespace WebQuanLyBanHang.Controllers
{
    public class WarehouseCardController : BaseController
	{
        [HttpGet]
        [Route("kho-nhap")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

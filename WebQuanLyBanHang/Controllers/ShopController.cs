using Microsoft.AspNetCore.Mvc;

namespace WebQuanLyBanHang.Controllers
{
    public class ShopController : BaseController
	{
        [HttpGet]
        [Route("tuy-chinh-shop")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

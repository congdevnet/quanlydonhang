using Microsoft.AspNetCore.Mvc;

namespace WebQuanLyBanHang.Controllers
{
    public class DeliveryAddressController : BaseController
	{
        [HttpGet]
        [Route("dia-chi-giao-hang")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

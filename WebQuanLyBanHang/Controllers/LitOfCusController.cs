using Microsoft.AspNetCore.Mvc;

namespace WebQuanLyBanHang.Controllers
{
    public class LitOfCusController : BaseController
	{
        public IActionResult Index()
        {
            return View();
        }
    }
}

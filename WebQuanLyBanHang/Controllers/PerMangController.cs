using Microsoft.AspNetCore.Mvc;

namespace WebQuanLyBanHang.Controllers
{
    public class PerMangController : BaseController
	{
        public IActionResult Index()
        {
            return View();
        }
    }
}

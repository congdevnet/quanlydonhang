using Microsoft.AspNetCore.Mvc;

namespace WebQuanLyBanHang.Controllers
{
    public class PersonalPageController : BaseController
	{
        public IActionResult Index()
        {
            return View();
        }
    }
}

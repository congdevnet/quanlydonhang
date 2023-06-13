using Microsoft.AspNetCore.Mvc;

namespace WebQuanLyBanHang.Controllers
{
    public class UserAdministrationController : BaseController
	{
        public IActionResult Index()
        {
            return View();
        }
    }
}

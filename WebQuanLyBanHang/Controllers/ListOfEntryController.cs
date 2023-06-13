using Microsoft.AspNetCore.Mvc;

namespace WebQuanLyBanHang.Controllers
{
    public class ListOfEntryController : BaseController
	{
        public IActionResult Index()
        {
            return View();
        }
    }
}

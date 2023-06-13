using Microsoft.AspNetCore.Mvc;

namespace WebQuanLyBanHang.Controllers
{
    public class ListOfExportController : BaseController
	{
        public IActionResult Index()
        {
            return View();
        }
    }
}

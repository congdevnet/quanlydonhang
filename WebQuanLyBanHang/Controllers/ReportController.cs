using Microsoft.AspNetCore.Mvc;

namespace WebQuanLyBanHang.Controllers
{
    public class ReportController : BaseController
	{
       /// <summary>
       /// [HttpGet]
       /// </summary>
       /// <returns></returns>
       // [Route("bao-cao")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebQuanLyBanHang.Models;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities.ViewModel;
using WebQuanLyBanHang.Utilities;

namespace WebQuanLyBanHang.Controllers
{
	public class CustomersBombController : BaseController
	{
		private readonly ICustomerService _customerService;
		private readonly ICustomerStatusService _customerStatusService;
		public CustomersBombController(ICustomerService customerService,
			ICustomerStatusService customerStatusService)
		{
			_customerService = customerService;
			_customerStatusService = customerStatusService;
		}
		[HttpGet]
		[Route("khach-bom-hang")]
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> Table(Pageding pageding)
		{
			PagedingMKT pagedingMKT = new PagedingMKT()
			{
				KeyWord = pageding.KeyWord,
				PageNum = pageding.PageNum,
				PageSize = pageding.PageSize,
				UserId = Guid.Parse(HttpContext.Request.Cookies[ConstSession.UserId]),
			};
			var data = await _customerService.GetCustomerBom(pagedingMKT);
			return View(data);
		}

	}
}

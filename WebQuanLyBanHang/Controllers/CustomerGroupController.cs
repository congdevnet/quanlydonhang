using Microsoft.AspNetCore.Mvc;
using WebQuanLyBanHang.Service.Infrastructure;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Controllers
{
	public class CustomerGroupController : BaseController
	{
		private readonly IGroupCustomerService _groupCustomerService;

		public CustomerGroupController(IGroupCustomerService groupCustomerService)
		{
			_groupCustomerService = groupCustomerService;
		}
		[HttpGet]
		[Route("nhom-khach-hang")]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Table(Pageding pageding)
		{
			var data = await _groupCustomerService.GetAll(pageding);
			return View(data);
		}

		[HttpPost]
		//[ValidateAntiForgeryToken]
		public async Task<IActionResult> Add([FromBody] GroupCustomerVM model)
		{
			if (!ModelState.IsValid)
			{
				return NotFound();
			}
			else
			{
				/// Thêm mới khi id = 0
				if (model.Id < 1)
				{
					await _groupCustomerService.Add(model);
				}
				else
				{
					await _groupCustomerService.Update(model);
				}

				return Ok(model.Id);
			}
		}
		[HttpGet]
		public async Task<IActionResult> GetModel(int id)
		{
			var data = await _groupCustomerService.Get(id);
			return Ok(data);
		}
		[HttpGet]
		public async Task<IActionResult> CheckData(string keyword)
		{
			var data = await _groupCustomerService.CheckData(keyword);
			return Ok(data);
		}
		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			await _groupCustomerService.Delete(id);
			return Ok();
		}
	}
}
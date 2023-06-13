using Microsoft.AspNetCore.Mvc;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities.ViewModel;
using WebQuanLyBanHang.Utilities;

namespace WebQuanLyBanHang.Controllers
{
    public class UnitController : BaseController
	{
        private readonly IUnitService  _unitService;
        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }
        [HttpGet]
        [Route("don-vi")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Table(Pageding pageding)
        {
            var data = await _unitService.GetAll(pageding);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UnitVM model)
        {
            /// Thêm mới khi id = 0
            if (model.Id < 1)
            {
                await _unitService.Add(model);
            }
            else
            {
                await _unitService.Update(model);
            }

            return Ok(model.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetModel(int id)
        {
            var data = await _unitService.Get(id);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> CheckData(string keyword)
        {
            var data = await _unitService.CheckData(keyword);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitService.Delete(id);
            return Ok();
        }
    }
}

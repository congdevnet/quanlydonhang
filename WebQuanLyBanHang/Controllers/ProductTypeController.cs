using Microsoft.AspNetCore.Mvc;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities.ViewModel;
using WebQuanLyBanHang.Utilities;

namespace WebQuanLyBanHang.Controllers
{
    public class ProductTypeController : BaseController
	{
        private readonly IClassifyProductService _classifyProductService;
        public ProductTypeController(IClassifyProductService classifyProductService)
        {
            _classifyProductService = classifyProductService;
        }
        [HttpGet]
        [Route("loai-san-pham")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Table(Pageding pageding)
        {
            var data = await _classifyProductService.GetAll(pageding);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ClassifyProductVM model)
        {
            /// Thêm mới khi id = 0
            if (model.Id < 1)
            {
                await _classifyProductService.Add(model);
            }
            else
            {
                await _classifyProductService.Update(model);
            }

            return Ok(model.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetModel(int id)
        {
            var data = await _classifyProductService.Get(id);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> CheckData(string keyword)
        {
            var data = await _classifyProductService.CheckData(keyword);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _classifyProductService.Delete(id);
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Controllers
{
    public class ProductListController : BaseController
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        private readonly IClassifyProductService _classifyProductService;
        private readonly IUnitService _unitService;
        private readonly IStatusProductService _statusProductService;
        private readonly IProductService _productService;

        public ProductListController(IClassifyProductService classifyProductService,
            IUnitService unitService, IStatusProductService statusProductService,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, IProductService productService)
        {
            this._classifyProductService = classifyProductService;
            this._unitService = unitService;
            this._statusProductService = statusProductService;
            this._hostingEnvironment = hostingEnvironment;
            this._productService = productService;
        }
        [HttpGet]
        [Route("danh-sach-san-pham")]
        public async Task<IActionResult> Index()
        {
            var data = await _productService.GetAll(new Pageding());
            return View(data);
        }
        [HttpGet]
        [Route("them-moi-san-pham")]
        public IActionResult Add()
        {
            GetSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("them-moi-san-pham")]
        public IActionResult Add(ProductVM ProductVM)
        {
            try
            {
                GetSelectList();
                if (!ModelState.IsValid)
                {
                    return View(ProductVM);
                }
                // Save file
                string wwwPath = this._hostingEnvironment.WebRootPath;
                string contentPath = this._hostingEnvironment.ContentRootPath;

                string path = Path.Combine(this._hostingEnvironment.WebRootPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileName = ProductVM.ProductImage.FileName;
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    ProductVM.ProductImage.CopyTo(stream);
                }
                // The end save //
                //Setup //
                ProductVM.InventoryNumber = ProductVM.Quanlity;

                _productService.Add(ProductVM);
                return RedirectToAction("Index", "ProductList");
            }
            catch (Exception ex)
            {
                return View(ProductVM);
            }
        }
        [HttpGet]
        [Route("sua-doi-san-pham")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var data = await _productService.Get(id);
            GetSelectList(data.ClassifyProductId, data.UnitId, data.StatusProductId);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("sua-doi-san-pham")]
        public async Task<IActionResult> Edit(ProductVM ProductVM)
        {
            try
            {
                GetSelectList(ProductVM.ClassifyProductId, ProductVM.UnitId
                    , ProductVM.StatusProductId);
                if (!ModelState.IsValid)
                {
                    return View(ProductVM);
                }
                // Save file
                string wwwPath = this._hostingEnvironment.WebRootPath;
                string contentPath = this._hostingEnvironment.ContentRootPath;

                string path = Path.Combine(this._hostingEnvironment.WebRootPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (ProductVM.ProductImage is not null)
                {
                    string fileName = ProductVM.ProductImage.FileName;
                    using (FileStream stream = new FileStream(Path.Combine(path, fileName),
                        FileMode.Create))
                    {
                        ProductVM.ProductImage.CopyTo(stream);
                    }
                }
                // The end save //
                await _productService.Update(ProductVM);
                return RedirectToAction("Index", "ProductList");
            }
            catch (Exception ex)
            {
                return View(ProductVM);
            }
        }

        private void GetSelectList(object? selectedCp = null,
            object? selectedUnit = null, object? selectedstapro = null)
        {
            ViewBag.ClassifyProduct = new SelectList(_classifyProductService.GetClassifyProductVMs(), "Id", "Name", selectedCp);
            ViewBag.Unit = new SelectList(_unitService.GetUnitVMs(), "Id", "Name", selectedUnit);
            ViewBag.StatusProduct = new SelectList(_statusProductService.Get(), "Id", "Name", selectedstapro);
        }
    }
}
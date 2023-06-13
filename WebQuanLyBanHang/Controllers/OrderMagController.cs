using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebQuanLyBanHang.Models;
using WebQuanLyBanHang.Service.Infrastructure;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Controllers
{
    /// Quan ly don hang
    public class OrderMagController : BaseController
    {
        private readonly ICustomerService _customerService;
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        private readonly IProvincesService _provincesService;
        private readonly IGroupCustomerService _groupCustomerService;
        private readonly IOrderSourceService _orderSourceService;
        private readonly IMethodDeliveryService _methodDeliveryService;
        private readonly IOrderInfoContentService _orderInfoContentService;
        private readonly IOrderStatusService _orderStatusService;
        private readonly ISingleTypeService _singleTypeService;
        private readonly IOrderService _orderService;

        public OrderMagController(ICustomerService customerService,
            IProvincesService provincesService, ICartService cartService,
            IProductService productService, IGroupCustomerService groupCustomerService,
            IOrderSourceService orderSourceService, IMethodDeliveryService methodDeliveryService,
            IOrderInfoContentService orderInfoContentService, IOrderStatusService orderStatusService,
            ISingleTypeService singleTypeService, IOrderService orderService)
        {
            _customerService = customerService;
            _provincesService = provincesService;
            _cartService = cartService;
            _productService = productService;
            _groupCustomerService = groupCustomerService;
            _orderSourceService = orderSourceService;
            _methodDeliveryService = methodDeliveryService;
            _orderInfoContentService = orderInfoContentService;
            _orderStatusService = orderStatusService;
            _singleTypeService = singleTypeService;
            _orderService = orderService;
        }
        [HttpGet]
        [Route("danh-sach-don-hang")]
        public async Task<IActionResult> Index()
        {
            await GetSelectList();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Table(Pageding pageding)
        {
            await GetSelectList();
            PagedingMKT pagedingMKT = new PagedingMKT()
            {
                KeyWord = pageding.KeyWord,
                PageNum = pageding.PageNum,
                PageSize = pageding.PageSize,
                StartDay = pageding.StartDay,
                EndDay = pageding.EndDay,
                OrderStatus = pageding.OrderStatus,
                UserId = Guid.Parse(HttpContext.Request.Cookies[ConstSession.UserId]),
            };
            var data = await _orderService.GetOrderOrder(pagedingMKT);
            ConvertProvinces(data.Items);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOrderBom([FromBody] CanceledOrderVM canceledOrder)
        {
            await _orderService.AddCanceledOrder(canceledOrder);
            return Ok();
        }
        [HttpGet]
        [Route("them-don-hang")]
        public async Task<IActionResult> Add(Guid id)
        {
            var check = await _orderService.GetCheckOrder(id);
            // add order //
            if (!check)
            {
                await _orderService.Add(new OrderVM(Guid.NewGuid(), DateTime.Now,
                Guid.Parse(HttpContext.Request.Cookies[ConstSession.UserId]), true), id);
            }
            var model = await _orderService.GetOrderInformation(id);
            await GetSelectList();

            return View(model);
        }
        [HttpGet]
        [Route("xem-don-hang")]
        public async Task<IActionResult> ViewOder(Guid id)
        {
            ConstPrameter.OrderId = id;
            var model = await _orderService.GetOrder(id);
            await GetSelectList();

            GetProvinces(model.CustomerOrder.CusCity,
                model.CustomerOrder.CusDistrict,
                model.CustomerOrder.Cusward);

            return View(model);
        }
        [HttpGet]
        [Route("sua-don-hang")]
        public async Task<IActionResult> Edit(Guid id)
        {
            ConstPrameter.OrderId = id;
            var model = await _orderService.GetOrder(id);
            await GetSelectList();

            GetProvinces(model.CustomerOrder.CusCity,
                model.CustomerOrder.CusDistrict,
                model.CustomerOrder.Cusward);

            return View(model);
        }

        [HttpPost]
        [Route("them-don-hang")]
        public async Task<IActionResult> Add(OrderInformationVM orderInformation)
        {
            await GetSelectList(null,null,null,null,null, 
                ConstPrameter.OrderStatusOrderId,null);

            if (!ModelState.IsValid)
            {
                return View(orderInformation);
            }
            else
            {
                Guid userId = Guid.Parse(HttpContext.Request.Cookies[ConstSession.UserId]);
                orderInformation.CartItems = _cartService.GetCartItems(HttpContext.Session);
                _cartService.ClearCart(HttpContext.Session);
                await _orderService.AddOrder(orderInformation, userId);
                return RedirectToAction("Index", "OrderMag");
            }
        }
        [HttpPost]
        [Route("sua-don-hang")]
        public async Task<IActionResult> Edit(OrderInformationVM orderInformation)
        {
            await GetSelectList();
            if (!ModelState.IsValid)
            {
                return View(orderInformation);
            }
            else
            {
                await _orderService.EditOrder(orderInformation);

                return RedirectToAction("Index", "OrderMag");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            //Xoa don hang da dat hang
            await _orderService.Delete(Guid.Parse(id));
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateConfirm(string orderId, int status)
        {
            //Xác nhận chốt đơn //
            await _orderService.UpdateConfirm(Guid.Parse(orderId), status);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetCart()
        {
            var data = _cartService.GetCartItems(HttpContext.Session);
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetCartItem()
        {
            var data = await _orderService.GetCartItem(ConstPrameter.OrderId);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> FindProduct(string keyword)
        {
            var data = await _productService.Gets(x => x.ProductName.Contains(keyword));
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct(string proId, int quantity)
        {
            Guid productId = Guid.Parse(proId);
            await _cartService.AddCart(productId, quantity, HttpContext.Session);
            return Ok();
        }

        [HttpGet]
        public IActionResult DeleteCart(string id)
        {
            Guid cartId = Guid.Parse(id);
            _cartService.RemoveCart(cartId, HttpContext.Session);
            return Ok();
        }

        private async Task GetSelectList(object? selectedpro = null,
            object? group = null, object? ordersou = null,
             object? method = null, object? orderin = null,
             object? orders = null, object? singlet = null
            )
        {
            ViewBag.Provinces = new SelectList(_provincesService.GetCity(), "MaDVHC", "Ten", selectedpro);

            ViewBag.GroupCustomer = new SelectList(await _groupCustomerService.Gets(), "Id", "Name", group);
            ViewBag.OrderSource = new SelectList(await _orderSourceService.Gets(), "Id", "Name", ordersou);
            ViewBag.MethodDelivery = new SelectList(await _methodDeliveryService.Gets(), "Id", "Name", method);
            ViewBag.OrderInfoContent = new SelectList(await _orderInfoContentService.Gets(), "Id", "Name", orderin);
            ViewBag.OrderStatus = new SelectList(await _orderStatusService.Gets(), "Id", "Name", orders);
            ViewBag.SingleType = new SelectList(await _singleTypeService.Gets(), "Id", "Name", singlet);
        }

        private void GetProvinces(object? selectedpro = null,
            object? cusDis = null, object? cusw = null)

        {
            ViewBag.CusDistrict = new SelectList(_provincesService.GetDistrict((int)selectedpro), "MaDVHC", "Ten", cusDis);
            ViewBag.Cusward = new SelectList(_provincesService.GetWard((int)cusDis), "MaDVHC", "Ten", cusw);
        }

        private void ConvertProvinces(List<OrderDetailed> orderDetaileds)
        {
            foreach (var item in orderDetaileds)
            {
                item.Address = _provincesService.GetProvincescs(item.Address, item.CityId,
                    item.DistrictId, item.WardId);
            }
        }

        public IActionResult GetDistrict(int city)
        {
            return Ok(_provincesService.GetDistrict(city));
        }

        public IActionResult GetWard(int district)
        {
            return Ok(_provincesService.GetWard(district));
        }
    }
}
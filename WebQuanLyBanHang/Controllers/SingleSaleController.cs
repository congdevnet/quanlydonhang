using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Service.Infrastructure;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities;
using static Azure.Core.HttpHeader;

namespace WebQuanLyBanHang.Controllers
{
    public class SingleSaleController : BaseController
    {
        private readonly ICustomerService _customerService;
        private readonly UserManager<User> _userManager;
        private readonly ICustomerStatusService _customerStatusService;
        public SingleSaleController(
            ICustomerService customerService,
            UserManager<User> userManager,
            ICustomerStatusService customerStatusService)
        {
            _customerService = customerService;
            _userManager = userManager;
            _customerStatusService = customerStatusService;
        }
        [Route("chia-sale")]
        public IActionResult Index()
        {
             GetSelectList();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Table(Pageding pageding)
        {
            var data = await _customerService.GetAll(pageding);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSale(string saleId, string cusId)
        {
            await _customerService.UpdateSale(Guid.Parse(saleId), cusId.Split(',').ToList());
            return Ok();
        }
        private void GetSelectList()
        {
            List<User> listUser = new List<User>();

            foreach (var user in _userManager.Users.ToList())
            {
                if (_userManager.GetRolesAsync(user).Result.FirstOrDefault() == "Sale")
                {
                    listUser.Add(user);
                }
            }
            ViewBag.UserSale = new SelectList(listUser, "Id", "UserName");
            ViewBag.SelectCus = new SelectList(_customerStatusService.GetCustomerStatus(), "Id", "Name");
        }
       
    }
}

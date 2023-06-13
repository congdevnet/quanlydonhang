using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Models;
using WebQuanLyBanHang.Service.Infrastructure;
using WebQuanLyBanHang.Service.Interface;
using WebQuanLyBanHang.Utilities;
using WebQuanLyBanHang.Utilities.ViewModel;

namespace WebQuanLyBanHang.Controllers
{
    
    public class UserController : BaseController
	{
        
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger _logger;
        private readonly IUserService _userService;
        public UserController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger logger, IUserService userService )
        {
            this._logger = logger; 
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._userService = userService;
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("dang-nhap")]
        public IActionResult Index()
        {
            var model = new LoginViewModel();
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("dang-nhap")]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
              
                var user =  await _userManager.Users.
                    FirstOrDefaultAsync(x=>x.UserName== model.UserName);
                if (user is null)
                {
                    ModelState.AddModelError(string.Empty, "Không tồn tại tài khoản!.");
                    return View(model);
                }
                else
                {
                    var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        var userrole =  _userManager.GetRolesAsync(user).Result.FirstOrDefault();

                        var claims = new List<Claim>() {
                            new Claim(ClaimTypes.Name, user.UserName),
                            new Claim(ClaimTypes.Email, user.Email),
                            new Claim(ClaimTypes.Role, userrole),
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                        };
						// Lưu trữ cookie
						HttpContext.Response.Cookies.Append(ConstSession.UserId, user.Id.ToString());

						_logger.LogInformation(1, "Người dùng đã đăng nhập.");

						return RedirectToAction("Index", "Home");
                    }
                    if (result.IsLockedOut)
                    {
                        _logger.LogWarning(2, "Tài khoản bị khóa.");
                        return View("Lockout");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Mật khẩu không đúng!.");
                        return View(model);
                    }
                }
            }
            _logger.LogInformation(1, "Người dùng đã đăng nhập.");
           
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation(4, "User đăng xuất.");
            return RedirectToAction(nameof(UserController.Index), "User");
        }
        [HttpGet]
        [Route("thong-tin-tai-khoan")]
        public async Task<IActionResult> GetUserId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = await _userManager.Users.
                FirstOrDefaultAsync(x => x.Id == Guid.Parse(userId));

            return View(model);
        }
        [HttpGet]
        [Route("danh-sach-nguoi-dung")]
        public IActionResult ViewUser()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Table(Pageding pageding)
        {
            var data = await _userService.GetAll(pageding);
            return View(data);
        }
        [HttpGet]
        [Route("doi-mat-khau")]
        public IActionResult ChangePassword(Guid id)
        {
            if(id == ConstPrameter.Guiddefault)
            {
                id = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            UserPaword userPaword = new UserPaword()
            {
                Id =id,
            };
            return View(userPaword);
        }
        [HttpPost]
        [Route("doi-mat-khau")]
        public async Task<IActionResult> ChangePassword(UserPaword userPaword)
        {
            if(!ModelState.IsValid)
            {
                return View(userPaword);
            }
            else
            {
                await _userService.ChangePassword(userPaword);
				await _signInManager.SignOutAsync();
				return RedirectToAction(nameof(UserController.Index), "User");
			}
        }
        public IActionResult GetResult(Guid id)
        {
			var data = _userService.Get(id).Result;
			return View(data);
		}
        [Route("them-moi-tai-khoan")]
        public IActionResult Add()
        {
            GetRole();
            return View();
        }
        [HttpPost]
        [Route("them-moi-tai-khoan")]
        public async Task<IActionResult> Add(UserVM userVM)
        {
            await _userService.Add(userVM);
            return RedirectToAction("ViewUser", "User");
        }
        private void GetRole()
        {
            ViewBag.Roles = new SelectList(_userService.GetListRole(), "Id", "Description");
        }
    }
}

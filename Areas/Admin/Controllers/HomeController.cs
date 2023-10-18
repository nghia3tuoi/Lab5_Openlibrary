using LAB5_HUYNHHUUNGHIA.Areas.Admin.Models;
using LAB5_HUYNHHUUNGHIA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAB5_HUYNHHUUNGHIA.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly OpenlibraryContext _openlibraryContext;
        public HomeController(OpenlibraryContext openlibraryContext)
        {
            _openlibraryContext = openlibraryContext;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginForm loginForm)
        {
            var user = await _openlibraryContext.Nhanviens.Where(nv => nv.UserName == loginForm.UserName).FirstOrDefaultAsync();
            if(user == null) {
                ViewBag.LoginUsername= "Tên đăng nhập không tồn tại!";
                return View();
            }
            if(user.Password != loginForm.Password)
            {
                ViewBag.LoginPassword = "Mật khẩu không chính xác!";
                return View();
            }
            return RedirectToAction("Index", "ChuyenNganh");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterForm registerForm)
        {
            var user = await _openlibraryContext.Nhanviens.Where(nv => nv.UserName == registerForm.UserName).FirstOrDefaultAsync();
            if (user != null)
            {
                ViewBag.RegisterUserName = "Tên đăng nhập đã tồn tại!";
                return View();
            }
            if(registerForm.Password != registerForm.PasswordAgain)
            {
                ViewBag.RegisterPassword = "Mật khẩu không khớp!";
                return View();
            }
            Nhanvien nv = new Nhanvien() { Password = registerForm.Password, UserName = registerForm.UserName };
            await _openlibraryContext.Nhanviens.AddAsync(nv);
            await _openlibraryContext.SaveChangesAsync();

            ViewBag.RegisterSuccess = "Đăng ký thành công!";
            return View();
        }
    }
}

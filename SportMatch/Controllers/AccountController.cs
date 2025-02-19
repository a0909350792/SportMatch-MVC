using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportMatch.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;

namespace SportMatch.Controllers
{
    public class AccountController : Controller
    {
        private readonly MemberContext _context;

        // 建構子，接收資料庫上下文
        public AccountController(MemberContext context)
        {
            _context = context;
        }

        // 顯示登入頁面
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // 處理登入邏輯
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User model, bool rememberMe)
        {
            if (ModelState.IsValid)
            {
                // 根據輸入的 Email 查找用戶
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

                // 確認用戶存在並且密碼正確
                if (user != null && user.Password == model.Password)
                {
                    // 設置登入的 Claims
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName!),
                        new Claim(ClaimTypes.Email, user.Email!),
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
                    };

                    // 創建 ClaimsIdentity 來代表登入的用戶
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    // 設定認證的屬性 (是否記住我)
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = rememberMe // 記住我功能
                    };

                    // 執行登入操作，使用 Cookies 來保存用戶認證
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authProperties);

                    // 設置登入成功訊息
                    ViewBag.Message = "登入成功!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // 如果用戶名或密碼錯誤，顯示錯誤訊息
                    ViewBag.ErrorMessage = "用戶名或密碼錯誤";
                }
            }

            // 如果表單驗證失敗，重新顯示登入頁面
            return View(model);
        }

        // 處理登出
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // 登出操作
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // 登出後重定向回首頁
            return RedirectToAction("Index", "Home");
        }
    }
}

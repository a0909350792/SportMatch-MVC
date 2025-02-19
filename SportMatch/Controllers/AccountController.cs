using Microsoft.AspNetCore.Mvc;
using SportMatch.Models;
using System.Linq;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace SportMatch.Controllers
{
    public class AccountController : Controller
    {
        // 註冊頁面
        [HttpGet]
        public IActionResult Register()
        {
            return View(); // 返回註冊視圖
        }
        private readonly UserContext _context;
        private readonly IConfiguration _configuration;

        public AccountController(UserContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // 1. 發送驗證碼接口
        [HttpPost]
        public IActionResult SendVerificationCode([FromBody] EmailModel model)
        {
            if (string.IsNullOrEmpty(model.Email))
            {
                return BadRequest(new { success = false, message = "電子郵件不可為空" });
            }

            var verificationCode = GenerateVerificationCode();
            bool isSent = SendEmail(model.Email, "您的驗證碼", $"您的驗證碼是：{verificationCode}");

            if (isSent)
            {
                // 可以選擇將驗證碼保存到資料庫或緩存中
                return Ok(new { success = true, message = "驗證碼已發送" });
            }
            else
            {
                return BadRequest(new { success = false, message = "發送驗證碼失敗" });
            }
        }

        // 2. 註冊接口
        [HttpPost]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // 檢查郵箱是否已註冊
                var existingUser = _context.Users.FirstOrDefault(u => u.Email == model.Email);
                if (existingUser != null)
                {
                    return BadRequest(new { success = false, message = "該郵箱已被註冊" });
                }

                // 密碼加密（這裡使用的是簡單示範，實際應使用加密算法，如 BCrypt 或 ASP.NET Identity）
                var hashedPassword = model.Password; // TODO: 請替換成加密邏輯

                // 創建新用戶
                var user = new User
                {
                    UserName = model.Username,
                    Email = model.Email,
                    Password = hashedPassword, // 加密後的密碼
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                return Ok(new { success = true, message = "註冊成功" });
            }

            return BadRequest(new { success = false, message = "註冊資料不正確" });
        }

        // 3. 登入接口
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                bool loginSuccess = ValidateUser(model.Email!, model.Password!);

                if (loginSuccess)
                {
                    return Ok(new { success = true, message = "登入成功" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "帳號或密碼錯誤" });
                }
            }

            return BadRequest(new { success = false, message = "登入資料不正確" });
        }

        // 驗證用戶帳號與密碼
        private bool ValidateUser(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return false; // 如果找不到該用戶，返回 false
            }

            // 比對密碼（這裡沒有加密邏輯，您可以添加加密邏輯來保護密碼）
            return user.Password == password; // 您應該使用加密來比較密碼
        }

        // 幫助方法：生成驗證碼（這是一個簡單範例，您可以根據需要改進）
        private string GenerateVerificationCode()
        {
            var random = new Random();
            return random.Next(1000, 9999).ToString();
        }

        // 幫助方法：模擬發送電子郵件（實際應該用真正的電子郵件發送服務）
        private bool SendEmail(string toEmail, string subject, string body)
        {
            // 在這裡使用您自己的發送郵件邏輯
            Console.WriteLine($"發送郵件到: {toEmail}, 主題: {subject}, 內容: {body}");
            return true;  // 假設郵件發送成功
        }
    }

    // 定義註冊模型
    public class RegisterModel
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    // 定義登入模型
    public class LoginModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    // 定義電子郵件模型
    public class EmailModel
    {
        public string? Email { get; set; }
    }
}

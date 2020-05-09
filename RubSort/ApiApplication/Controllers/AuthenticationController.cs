using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RubSort.ApiApplication.Models;
using RubSort.IdentitySystem;

namespace RubSort.ApiApplication.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly AuthenticationManager authenticationManager;

        public AuthenticationController(AuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
        }
        
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = authenticationManager.Login(model.Email);
            if (result != null)
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(result));
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            
            return View(model);
        }

        // GET
        public IActionResult Register()
        {
            return View();
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var result = authenticationManager.Register(model.Email, model.Password);
            if (result != null)
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(result));
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            return View(model);
        }
        
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult ResetPassword(RegisterModel model)
        {
            if (!ModelState.IsValid) return View();
            
            authenticationManager.ChangePassword(model.Email, model.Password);

            return View("Login");
        }

        public async void Logout()
        {
            await HttpContext.SignOutAsync();
        }
        
        public IActionResult ForgotPassword()
        {
            return View("ResetPassword");
        }
    }
}
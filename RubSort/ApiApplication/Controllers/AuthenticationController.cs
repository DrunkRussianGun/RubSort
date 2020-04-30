using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ApiApplication.Models;
using IdentitySystem;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace ApiApplication.Controllers
{
    public class AuthenticationController : Controller
    {
        private AuthenticationManager _authenticationManager;

        public AuthenticationController(AuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }
        
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = _authenticationManager.Login(model.Email).Result;

            if (_authenticationManager.IsRegisteredUser(model.Email))
            {
                var id = _authenticationManager.Login(model.Email).Result;
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
                //await Authenticate(model.Email); 

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
            if (_authenticationManager.IsRegisteredUser(model.Email))
            {
                var id = _authenticationManager.Register(model.Email, model.Password).Result;
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
                
                //await Authenticate(model.Email);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            return View(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> ResetPassword()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> ResetPassword(RegisterModel model)
        {
            if (!ModelState.IsValid) return View();
            
            _authenticationManager.ChangePassword(model.Email, model.Password);

            return View("Login");
        }

        
        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public void Logout()
        {
            
        }
        
        public void ForgotPassword()
        {
            
        }
    }
}
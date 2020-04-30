using System.Security.Claims;
using System.Threading.Tasks;
using Api;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class AuthenticationController : Controller
    {
        private ApiClient _apiClient;

        public AuthenticationController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [HttpGet]
        public IActionResult Login() => View();

        public IActionResult Register()
        {
            return View();
        }
        
        public IActionResult ResetPassword()
        {
            return View();
        }
        
        public IActionResult ForgetPassword()
        {
            return View("ResetPassword");
        }

        public IActionResult Logout()
        {
            return View("Login");
        }
    }
}
﻿using Microsoft.AspNetCore.Mvc;

namespace RubSort.WebApplication.Controllers
{
    public class AuthenticationController : Controller
    {
        private ApiClient.ApiClient _apiClient;

        public AuthenticationController(ApiClient.ApiClient apiClient)
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
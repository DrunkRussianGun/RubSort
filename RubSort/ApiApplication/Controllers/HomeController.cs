﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RubSort.ApiApplication.Models;

namespace RubSort.ApiApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Plastic() => View();
        public IActionResult Paper() => View();
        public IActionResult Aluminum() => View();

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
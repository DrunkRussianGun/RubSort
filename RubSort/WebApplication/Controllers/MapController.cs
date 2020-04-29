using Api;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class MapController : Controller
    {
        private ApiClient _apiClient;

        public MapController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        // GET
        public IActionResult Render()
        {
            return View();
        }
    }
}
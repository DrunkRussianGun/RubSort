using Microsoft.AspNetCore.Mvc;

namespace RubSort.WebApplication.Controllers
{
    public class MapController : Controller
    {
        private ApiClient.ApiClient _apiClient;

        public MapController(ApiClient.ApiClient apiClient)
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
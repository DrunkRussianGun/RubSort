using Microsoft.AspNetCore.Mvc;

namespace RubSort.WebApplication.Controllers
{
    public class MapController : Controller
    {
        private ApiClient.ApiClient apiClient;

        public MapController(ApiClient.ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }
        
        [HttpGet]
        public IActionResult Render()
        {
            return View();
        }
    }
}
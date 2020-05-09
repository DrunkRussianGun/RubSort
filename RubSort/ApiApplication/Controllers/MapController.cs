using System;
using Microsoft.AspNetCore.Mvc;
using RubSort.MapSystem;

namespace RubSort.ApiApplication.Controllers
{
    public class MapController : Controller
    {
        private MapRenderer mapRenderer;

        public MapController(MapRenderer mapRenderer)
        {
            this.mapRenderer = mapRenderer;
        }
        
        [HttpGet]
        public IActionResult Render()
        {
            //todo
            throw new NotImplementedException();
        }
    }
}
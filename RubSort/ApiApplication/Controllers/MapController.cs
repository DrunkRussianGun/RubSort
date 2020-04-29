using System;
using MapSystem;
using Microsoft.AspNetCore.Mvc;

namespace ApiApplication.Controllers
{
    public class MapController : Controller
    {
        private MapRenderer _mapRenderer;

        public MapController(MapRenderer mapRenderer)
        {
            _mapRenderer = mapRenderer;
        }
        // GET
        public IActionResult Render()
        {
            //todo
            throw new NotImplementedException();
        }
    }
}
using System;
using Microsoft.AspNetCore.Mvc;
using RubSort.ApiApplication.Models;
using RubSort.MapSystem;

namespace RubSort.ApiApplication.Controllers
{
    public class MapController : Controller
    {
        private readonly MapGetter mapGetter;

        public MapController(MapGetter mapGetter)
        {
            this.mapGetter = mapGetter;
        }
        
        [HttpGet]
        public IActionResult Get(MapContextModel mapContext)
        {
            var validationResult = mapContext.ToDomainModel();

            throw new NotImplementedException();
        }
    }
}
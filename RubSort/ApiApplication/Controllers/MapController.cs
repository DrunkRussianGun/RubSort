using GeoCoordinatePortable;
using Microsoft.AspNetCore.Mvc;
using RubSort.ApiApplication.Models.Map;
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
        public IActionResult Get()
        {
            var context = new MapContextModel
            {
                InitialPoint = new GeoCoordinate(55.7848, 49.1144),
                Zoom = 13.0
            };
            var map = Get(context);

            var model = new MapViewModel
            {
                MapRenderingScript = map.MapRenderingScript,
                MapConfigurationScript = map.MapConfigurationScript
            };
            return View(model);
        }
        
        private Map Get(MapContextModel mapContext)
        {
            var context = mapContext.ToDomainModel();
            return mapGetter.GetMap(context);
        }
    }
}
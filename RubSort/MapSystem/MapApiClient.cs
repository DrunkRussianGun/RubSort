using System;
using System.Net.Http;
using GeoCoordinatePortable;

namespace RubSort.MapSystem
{
    public class MapApiClient
    {
        private HttpClient _httpClient;
        
        public string GetScriptWithMap(
            MapRenderingContext context)
        {
            //todo
            throw new NotImplementedException();
        }

        public GeoCoordinate GetCoordinate(string point)
        {
            //todo
            throw new NotImplementedException();
        }
            
    }
}
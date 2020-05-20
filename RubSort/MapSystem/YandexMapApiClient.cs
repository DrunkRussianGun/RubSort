using System.Globalization;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RubSort.RecyclingPointsSystem;

namespace RubSort.MapSystem
{
    public class YandexMapApiClient : IMapApiClient
    {
        private const string apiKeySetting = "YandexMapApi:ApiKey";
        private const string yandexMapApiBaseUrlSetting = "YandexMapApiBaseUrl";
        private const string yandexMapApiOrganizationsUrlSetting = "YandexMapApiOrganizationsUrl";
        
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;

        public YandexMapApiClient(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
        }

        public Map GetMap(MapContext context)
        {
            var apiKey = configuration[apiKeySetting];
            var mapRenderingScript = RenderMap(apiKey);
            
            var mapConfigurationScript = ConfigureMap(context);
            
            return new Map
            {
                MapRenderingScript = mapRenderingScript,
                MapConfigurationScript = mapConfigurationScript
            };
        }

        public RecyclingPoint GetInfo(RecyclingPoint recyclingPoint)
        {
            var apiKey = configuration[apiKeySetting];
            var apiBaseUrl = configuration[yandexMapApiBaseUrlSetting];
            var apiOrganizationsUrl = configuration[yandexMapApiOrganizationsUrlSetting];

            // с помощью httpClient отправить запрос по адресу apiBaseUrl + apiOrganizationsUrl
            var response = httpClient.GetAsync(apiBaseUrl + apiOrganizationsUrl).Result;
            var jsonString = response.Content.ReadAsStringAsync().Result;
            
            var recyclingPointInfo = new RecyclingPoint();
            // по полученному ответу заполнить recyclingPointInfo
            recyclingPointInfo = JsonConvert.DeserializeObject<RecyclingPoint>(jsonString);
            
            return recyclingPointInfo;
        }

        private string RenderMap(string apiKey)
        {
            return $@"
    <script
        src=""https://api-maps.yandex.ru/2.1/?lang=ru_RU&amp;apikey={apiKey}""
        type=""text/javascript""></script>";
        }

        private string ConfigureMap(MapContext context)
        {
            var builder = new StringBuilder();
            builder.Append($@"<script type=""text/javascript"">
                        ymaps.ready(init);
                        function init() {{
                            var myMap = new ymaps.Map(""map"", {{ 
                                center: [
{context.InitialPoint.Latitude.ToString(NumberFormatInfo.InvariantInfo)},
{context.InitialPoint.Longitude.ToString(NumberFormatInfo.InvariantInfo)}],
                                zoom: {context.Zoom}
                            }});");

            var points = context.RecyclingPoints;
            foreach (var point in points)
            {
                var newPoint = GetInfo(point);
                builder.Append(
                    $@"var myPlacemark = new ymaps.Placemark([{newPoint.GeoCoordinate.Latitude}, {newPoint.GeoCoordinate.Longitude}]);
                    myMap.geoObjects.add(myPlacemark);");
            }

            builder.Append(@"}
                    </script>");
            return builder.ToString();
        }
    }
}
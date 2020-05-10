using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using RubSort.Core;
using RubSort.RecyclingPointsSystem;

namespace RubSort.MapSystem
{
    public class YandexMapApiClient : IMapApiClient
    {
        private const string yandexMapApiKeySetting = "YandexMapApiKey";
        private const string yandexMapApiBaseUrlSetting = "YandexMapApiBaseUrl";
        private const string yandexMapApiOrganizationsUrlSetting = "YandexMapApiOrganizationsUrl";
        
        private readonly HttpClient httpClient;
        private readonly ISettingsManager settingsManager;

        public YandexMapApiClient(HttpClient httpClient, ISettingsManager settingsManager)
        {
            this.httpClient = httpClient;
            this.settingsManager = settingsManager;
        }

        public Map GetMap(MapContext context)
        {
            var apiKey = settingsManager.GetSetting(yandexMapApiKeySetting);
            var htmlScript = GenerateMap(context, apiKey); // сгенерировать скрипт с картой
            return new Map { HtmlScript = htmlScript };
        }

        public RecyclingPoint GetInfo(RecyclingPoint recyclingPoint)
        {
            var apiKey = settingsManager.GetSetting(yandexMapApiKeySetting);
            var apiBaseUrl = settingsManager.GetSetting(yandexMapApiBaseUrlSetting);
            var apiOrganizationsUrl = settingsManager.GetSetting(yandexMapApiOrganizationsUrlSetting);

            // с помощью httpClient отправить запрос по адресу apiBaseUrl + apiOrganizationsUrl
            var response = httpClient.GetAsync(apiBaseUrl + apiOrganizationsUrl).Result;
            var jsonString = response.Content.ReadAsStringAsync().Result;
            
            var recyclingPointInfo = new RecyclingPoint();
            // по полученному ответу заполнить recyclingPointInfo
            recyclingPointInfo = JsonConvert.DeserializeObject<RecyclingPoint>(jsonString);
            
            return recyclingPointInfo;
        }

        private string GenerateMap(MapContext context, string apiKey)
        {
            var builder = new StringBuilder();
            builder.Append($@"<!DOCTYPE html>
                <html xmlns=""http://www.w3.org/1999/xhtml"">
                <head>
                    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
                    <script src=""https://api-maps.yandex.ru/2.1/?apikey={apiKey}&lang=ru_RU"" type=""text/javascript"">
                    </script>
                    <script type=""text/javascript"">
                        ymaps.ready(init);
                        function init() {{
                            var myMap = new ymaps.Map(""map"", {{ 
                                center: [{context.InitialPoint.Latitude}, {context.InitialPoint.Longitude}],
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
                    </script>
                </head>

                <body>
                    <div id=""map"" style=""width: 1000px; height: 600px""></div>
                </body>
                </html>");
            return builder.ToString();
        }
    }
}
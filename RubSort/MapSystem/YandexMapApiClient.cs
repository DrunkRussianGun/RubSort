using System;
using System.Net.Http;
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
            var htmlScript = (string)null ?? throw new NotImplementedException(); // сгенерировать скрипт с картой
            return new Map { HtmlScript = htmlScript };
        }

        public RecyclingPoint GetInfo(RecyclingPoint recyclingPoint)
        {
            var apiKey = settingsManager.GetSetting(yandexMapApiKeySetting);
            var apiBaseUrl = settingsManager.GetSetting(yandexMapApiBaseUrlSetting);
            var apiOrganizationsUrl = settingsManager.GetSetting(yandexMapApiOrganizationsUrlSetting);
            
            // с помощью httpClient отправить запрос по адресу apiBaseUrl + apiOrganizationsUrl
            
            var recyclingPointInfo = new RecyclingPoint();
            // по полученному ответу заполнить recyclingPointInfo
            return recyclingPointInfo;
        }
    }
}
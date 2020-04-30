using System;
using System.Net.Http;
using System.Security.Claims;
using MapSystem;
using ApiApplication;

namespace Api
{
    public class ApiClient
    {
        private HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        //...
    }
}
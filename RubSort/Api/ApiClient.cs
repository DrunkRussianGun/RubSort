using System;
using System.Net.Http;
using MapSystem;

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
using System.Net.Http;

namespace RubSort.ApiClient
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
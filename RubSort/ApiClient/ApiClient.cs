using System.Net.Http;

namespace RubSort.ApiClient
{
    public class ApiClient
    {
        private HttpClient httpClient;

        public ApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }
}
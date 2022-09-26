using FirstWebApi.ApiClients.Contracts;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace FirstWebApi.ApiClients
{
    public class JsonPlaceholderApiClient
    {
        private readonly string _baseUrl = "https://jsonplaceholder.typicode.com";
        private readonly string _apiKey = "random-api-key";

        private IHttpClientFactory _httpClientFactory;

        public JsonPlaceholderApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<PlaceholderUser>> FetchData()
        {
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Add("x-api-key", _apiKey);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("x-api-key", "=" + _apiKey);
            httpClient.BaseAddress = new Uri(_baseUrl);

            return await httpClient.GetFromJsonAsync<List<PlaceholderUser>>("users");
        }
    }
}

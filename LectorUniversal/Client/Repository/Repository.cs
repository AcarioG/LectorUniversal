using System.Text;
using System.Text.Json;

namespace LectorUniversal.Client.Repository
{
    public class Repository : IRepository
    {
        private readonly HttpClient _httpClient;
        public Repository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data)
        {
            var json = JsonSerializer.Serialize(data);
            var context = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, context);
            return new HttpResponseWrapper<object>(null, !response.IsSuccessStatusCode, response);
        }
    }
}

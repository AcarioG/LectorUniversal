using LectorUniversal.Client.Helpers;
using System.Text;
using System.Text.Json;

namespace LectorUniversal.Client.Repository
{
    public class Repository : IRepository
    {
        private readonly HttpClientWithToken _httpClientToken;
        private readonly HttpClientWithoutToken _httpClientWithoutToken;

        public Repository(HttpClientWithToken httpClientToken, HttpClientWithoutToken httpClientWithoutToken)
        {
            _httpClientToken = httpClientToken;
            _httpClientWithoutToken = httpClientWithoutToken;
        }

        public async Task<HttpResponseWrapper<T>> Get<T>(string url, bool includeToken = true)
        {
            HttpClient httpClient;

            if (includeToken)
                httpClient = _httpClientToken.HttpClient;
            else
                httpClient = _httpClientWithoutToken.HttpClient;

            var responseHttp = await httpClient.GetAsync(url);

            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await DeserializeResponse<T>(responseHttp, _serializerOptions);
                return new HttpResponseWrapper<T>(response, false, responseHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(default, false, responseHttp);
            }
        }
        private JsonSerializerOptions _serializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true};

        private async Task<T> DeserializeResponse<T>(HttpResponseMessage httpResponseMessage, JsonSerializerOptions jsonOptions)
        {
            var responseString = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, jsonOptions);
        }

        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data)
        {
            var json = JsonSerializer.Serialize(data);
            var context = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClientToken.HttpClient.PostAsync(url, context);
            return new HttpResponseWrapper<object>(null, !response.IsSuccessStatusCode, response);
        }

        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T data)
        {
            var json = JsonSerializer.Serialize(data);
            var context = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClientToken.HttpClient.PutAsync(url, context);
            return new HttpResponseWrapper<object>(null, !response.IsSuccessStatusCode, response);
        }

        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data)
        {
            var json = JsonSerializer.Serialize(data);
            var context = new StringContent(json, Encoding.UTF8, "application/json");
            var responseHttp = await _httpClientToken.HttpClient.PostAsync(url, context);
            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await DeserializeResponse<TResponse>(responseHttp, _serializerOptions);
                return new HttpResponseWrapper<TResponse>(response, false, responseHttp);
            }
            else
            {
                return new HttpResponseWrapper<TResponse>(default, true, responseHttp);
            }
        }

        public async Task<HttpResponseWrapper<object>> Delete(string url)
        {
            var responseHttp = await _httpClientToken.HttpClient.DeleteAsync(url);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }
    }
}

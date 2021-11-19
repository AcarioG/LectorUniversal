namespace LectorUniversal.Client.Repository
{
    public interface IRepository
    {
        Task<HttpResponseWrapper<T>> Get<T>(string url);
        Task<HttpResponseWrapper<object>> Post<T>(string url, T data);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data);
    }
}

namespace LectorUniversal.Client.Repository
{
    public interface IRepository
    {
        Task<HttpResponseWrapper<object>> Post<T>(string url, T data);
    }
}

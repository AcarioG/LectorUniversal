namespace LectorUniversal.Client.Repository
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Error = error;
            HttpResponseMessage = httpResponseMessage;
            Response = response;
        }

        public bool Error { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }
        public T Response { get; set; }
    }
}

namespace HttpClientImplement.Services
{
    public interface IHttpCientService
    {
        Task<HttpClientResponse<T>> GetAsync<T>(string Url);
        Task<HttpClientResponse<string>> GetStringAsync(string Url);
        Task<HttpClientResponse<Out>> PostAsync<In, Out>(string Url, In Input);
    }
}

namespace VB.Movie.Application.Interfaces.Wrappers
{
    public interface IHttpClientWrapper
    {
        Task<T> PostAsync<T>(string url, object body);
        Task PostAsync(string url, object body);
        Task<T> GetAsync<T>(string imdbId);
        Task<T> PutAsync<T>(string url, object body);

        string GetIPAddress();
    }
}

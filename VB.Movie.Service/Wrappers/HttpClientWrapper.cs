using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using VB.Movie.Application.Interfaces.Wrappers;
using VB.Movie.Application.Utils;

namespace VB.Movie.Application.Wrappers
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _client;
        private readonly IOptions<AppSettingsModel> _configurationService;
        private readonly IHttpContextAccessor _accessor;


        public HttpClientWrapper(HttpClient client, IOptions<AppSettingsModel> configurationservice, IHttpContextAccessor accessor)
        {
            _client = client;
            _configurationService = configurationservice;
            _accessor = accessor;
        }

        public HttpClient Client => _client;

        public async Task<T> PostAsync<T>(string url, object body)
        {
            var response = await _client.PostAsync(url, new JsonContent(body));

            response.EnsureSuccessStatusCode();

            var respnoseText = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(respnoseText);
            return data;
        }

        public async Task PostAsync(string url, object body)
        {
            var response = await _client.PostAsync(url, new JsonContent(body));

            response.EnsureSuccessStatusCode();
        }

        public async Task<T> PutAsync<T>(string url, object body)
        {
            var response = await _client.PutAsync(url, new JsonContent(body));

            response.EnsureSuccessStatusCode();

            var respnoseText = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(respnoseText);
            return data;
        }

        public async Task<T> GetAsync<T>(string imdbId)
        {

            var query = new Dictionary<string, string>()
            {
                ["i"] = imdbId,
                ["apikey"] = _configurationService.Value.ApiKey
            };

            var uri = QueryHelpers.AddQueryString($"http://www.omdbapi.com", query);

            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            var response = await _client.GetAsync(uri);

            response.EnsureSuccessStatusCode();

            var respnoseText = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(respnoseText);
            return data;
        }

        public string GetIPAddress()
        {
            return _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NUnitBackendTests.Adapters
{
    public class HttpAdapter
    {
        private readonly HttpClient _httpClient;
        private string BaseUrl { get; set; }

        public HttpAdapter(string baseUrl)
        {
            _httpClient = new HttpClient();
            BaseUrl = baseUrl;
        }

        public async Task<HttpResponseMessage> GetAsync(string url, Dictionary<string, string>? parameters = null)
        {
            if (parameters?.Any() == true)
            {
                var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={p.Value}"));
                url = $"{url}?{queryString}";
            }

            return await _httpClient.GetAsync(BaseUrl + url);
        }

        public async Task<HttpResponseMessage> PutAsync(string url, object content)
        {
            var json = JsonConvert.SerializeObject(content);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PutAsync(url, stringContent);
        }
    }
}

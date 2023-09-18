using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Reflection.PortableExecutable;
using System.Net.Http;

namespace XoperoCore.RestClient
{
    public class RestClient : IRestService
    {
        private readonly IHttpClientFactory _httpClientFactory = null!;

        public RestClient(IHttpClientFactory httpClient)
        {
            _httpClientFactory = httpClient;
        }

        public async Task<HttpResponseMessage> ExecuteGetAsync(string uri, string jsonContent = null)
        {
            using HttpClient client = _httpClientFactory.CreateClient("hostingServiceHttpClient");

            HttpResponseMessage result = null;

            if (string.IsNullOrEmpty(jsonContent))
            {
                result = await client.GetAsync(uri);
            }
            else
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(uri),
                    Content = new StringContent(jsonContent, Encoding.UTF8, "application/json"),
                };
                result = await client.SendAsync(request);
            }

            return result;
        }

        public async Task<HttpResponseMessage> ExecutePostAsync(string uri, string jsonContent, string serviceAccessToken)
        {
            using HttpClient client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", serviceAccessToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
            client.DefaultRequestHeaders
             .UserAgent
             .TryParseAdd("MyAgent");
            StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            return await client.PostAsync(uri, content);
        }

        public async Task<HttpResponseMessage> ExecutePatchAsync(string url, string jsonContent, string serviceAccessToken)
        {
            using HttpClient client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", serviceAccessToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
            client.DefaultRequestHeaders
             .UserAgent
             .TryParseAdd("MyAgent");
            StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            return await client.PatchAsync(url, content);
        }
    }
}

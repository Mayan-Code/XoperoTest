using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace XoperoCore.RestClient
{
    public class RestClient : IRestService
    {
        private readonly IHttpClientFactory _httpClientFactory = null!;

        public RestClient(IHttpClientFactory httpClient)
        {
            _httpClientFactory = httpClient;
        }

        public async Task ExecuteGetAsync(string uri, string jsonContent = null)
        {
           
        }

        public async Task ExecutePostAsync(string uri, string jsonContent)
        {
        }

        public async Task ExecutePutAsync(string url, string jsonContent)
        {
        }
    }
}

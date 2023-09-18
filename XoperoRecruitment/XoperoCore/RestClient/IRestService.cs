using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoperoCore.RestClient
{
    internal interface IRestService
    {
        Task<HttpResponseMessage> ExecuteGetAsync(string uri, string jsonContent = null);
        Task<HttpResponseMessage> ExecutePostAsync(string uri, string jsonContent, string serviceAccessToken);
        Task<HttpResponseMessage> ExecutePatchAsync(string url, string jsonContent, string serviceAccessToken);
    }
}

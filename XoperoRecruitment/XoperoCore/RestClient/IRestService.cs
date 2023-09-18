using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoperoCore.RestClient
{
    internal interface IRestService
    {
        Task ExecuteGetAsync(string uri, string jsonContent = null);
        Task ExecutePostAsync(string uri, string jsonContent);
        Task ExecutePutAsync(string url, string jsonContent);
    }
}

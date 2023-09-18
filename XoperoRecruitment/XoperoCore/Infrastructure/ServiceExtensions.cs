using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XoperoCore.HostingService;
using XoperoCore.RestClient;

namespace XoperoCore.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void AddXoperoCoreServices(this IServiceCollection services)
        {
            services.AddHttpClient("hostingServiceHttpClient", config =>
            {
                config.DefaultRequestHeaders.Clear();
                config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
            services.AddScoped<IHosting, GitHubHostingService>();
            services.AddSingleton<IRestService, RestClient.RestClient>();
        }
    }
}

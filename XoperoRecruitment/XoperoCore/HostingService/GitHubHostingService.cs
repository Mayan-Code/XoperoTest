using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoperoCore.RestClient;
using Microsoft.Extensions.DependencyInjection;
using XoperoCore.HostingService.Models;
using System.Net.Http;

namespace XoperoCore.HostingService
{
    internal class GitHubHostingService : HostingBase, IHosting
    {
        protected override string BaseUrl => "https://api.github.com/repos";
        protected override string HostingName => "GitHub";


        IRestService _restService;

        public GitHubHostingService(IRestService restService)
        {
            _restService = restService;
        }

        public string GetHostingName() => HostingName;

        public async Task AddNewIssue(NewIssueModel issueModel)
        {
            throw new NotImplementedException();
        }

        public async Task CloseIssue(long issueId)
        {
            throw new NotImplementedException();
        }

        public async Task GetAllIssue()
        {
            throw new NotImplementedException();
        }

        public async Task GetIssue(long issueId)
        {
            throw new NotImplementedException();
        }
    }
}

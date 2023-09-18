using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoperoCore.RestClient;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using XoperoCore.HostingService.GitHub.Models;
using Newtonsoft.Json;
using XoperoCore.HostingService.Common;

namespace XoperoCore.HostingService.GitHub
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

        public async Task AddNewIssue(string title, string body)
        {
            var result = await _restService.ExecutePostAsync($"{BaseUrl}/{RepositoryUserName}/{RepositoryName}/issues",
               JsonConvert.SerializeObject(new NewIssueModel { Name = title, Description = body}), RepositoryPAT);
        }

        public async Task CloseIssue(long issueId)
        {
            var result = await _restService.ExecutePatchAsync($"{BaseUrl}/{RepositoryUserName}/{RepositoryName}/issues/{issueId}",
                JsonConvert.SerializeObject(new IssueClose()), RepositoryPAT);

        }
        public async Task EditIssue(long issueId, string title, string description)
        {
            var result = await _restService.ExecutePatchAsync($"{BaseUrl}/{RepositoryUserName}/{RepositoryName}/issues/{issueId}",
                JsonConvert.SerializeObject(new IssueEdit { Description = description, Name = title}), RepositoryPAT);
        }

        public async Task<List<IssueModel>> GetAllIssue(string repositoryUserName, string repositoryName, string repositoryPAT)
        {
            RepositoryUserName = repositoryUserName;
            RepositoryName = repositoryName;
            RepositoryPAT = repositoryPAT;

            var result = await _restService.ExecuteGetAsync($"{BaseUrl}/{RepositoryUserName}/{RepositoryName}/issues");
            if(result.IsSuccessStatusCode)
            {
                var jsonResult = await result.Content.ReadAsStringAsync();
                List<Issue> issues = JsonConvert.DeserializeObject<List<Issue>>(jsonResult);
                List<IssueModel> resultBack = new List<IssueModel>();

                foreach (var item in issues)
                {
                    resultBack.Add(new IssueModel
                    {
                        Description = item.Description,
                        Id = item.Id,
                        Name = item.Name,
                    });
                }
                return resultBack;
            }
            return null;
        }

        public async Task<IssueModel> GetIssue(long issueId)
        {
            var result = await _restService.ExecuteGetAsync($"{BaseUrl}/{RepositoryUserName}/{RepositoryName}/issues/{issueId}");
            if (result.IsSuccessStatusCode)
            {
                var jsonResult = await result.Content.ReadAsStringAsync();
                Issue issue = JsonConvert.DeserializeObject<Issue>(jsonResult);
                IssueModel resultBack = new IssueModel
                {
                    Description = issue.Description,
                    Id = issue.Id,
                    Name = issue.Name,
                };
                return resultBack;
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoperoCore.HostingService.Common;
using XoperoCore.HostingService.GitHub.Models;
using XoperoCore.RestClient;

namespace XoperoCore.HostingService
{
    public interface IHosting
    {
        string GetHostingName();
        Task<List<IssueModel>> GetAllIssue(string repositoryUserName, string repositoryName, string repositoryPAT);
        Task<IssueModel> GetIssue(long issueId);
        Task AddNewIssue(string title, string body);
        Task CloseIssue(long issueId);
        Task EditIssue(long issueId, string title, string description);
    }
}

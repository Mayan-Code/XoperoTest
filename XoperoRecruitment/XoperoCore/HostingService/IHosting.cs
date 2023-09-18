using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XoperoCore.HostingService.Models;
using XoperoCore.RestClient;

namespace XoperoCore.HostingService
{
    public interface IHosting
    {
        string GetHostingName();
        Task GetAllIssue();
        Task GetIssue(long issueId);
        Task AddNewIssue(NewIssueModel newIssue);
        Task CloseIssue(long issueId);
    }
}

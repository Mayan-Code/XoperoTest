using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoperoCore.HostingService.Models
{
    public class NewIssueModel : BaseModel
    {
        public string IssueName { get; set; }
        public string IssueDescription { get; set; }
    }
}

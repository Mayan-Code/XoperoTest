using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoperoCore.HostingService.GitHub.Models
{
    internal class IssueClose
    {
        [JsonProperty("state")]
        public string State { get; set; } = "closed";
    }
}

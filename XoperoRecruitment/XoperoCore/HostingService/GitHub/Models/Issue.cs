using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoperoCore.HostingService.GitHub.Models
{
    internal class Issue
    {
        [JsonProperty("number")]
        public long Id { get; set; }
        [JsonProperty("title")]
        public string Name { get; set; }
        [JsonProperty("body")]
        public string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoperoCore.HostingService
{
    internal abstract class HostingBase
    {
        protected abstract string BaseUrl { get; }
        protected abstract string HostingName { get; }
        private string _repositoryUserName;
        private string _repositoryName;
        private string _repositoryPAT;
        public string RepositoryUserName { get { return _repositoryUserName; } set { if (!string.IsNullOrEmpty(value)) _repositoryUserName = value; else { }   } }
        public string RepositoryName { get { return _repositoryName; } set { if (!string.IsNullOrEmpty(value)) _repositoryName = value; else { }   } }
        public string RepositoryPAT{ get { return _repositoryPAT; } set { if (!string.IsNullOrEmpty(value)) _repositoryPAT = value; else { }   } }
    }
}

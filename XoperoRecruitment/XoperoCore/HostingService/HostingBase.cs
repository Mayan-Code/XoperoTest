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
    }
}

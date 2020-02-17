using System;
using System.Collections.Generic;
using System.Text;

namespace Toolbox.Common.RestEase
{
    public class RestEaseOptions
    {
        public IEnumerable<Service> Services { get; set; }
    }

    public class Service
    {
        public string Name { get; set; }
        public string Scheme { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}

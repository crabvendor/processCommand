using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessCommander.Models
{
    public class ResourcesModel
    {
        public string OperatingSystemInfo => System.Runtime.InteropServices.RuntimeInformation.OSDescription;

        public string Os => Environment.OSVersion.ToString();
        public string UserName => Environment.UserName;

        public string MachineName => Environment.MachineName;
        public string ProcessorInfo { get; set; }
    }
}

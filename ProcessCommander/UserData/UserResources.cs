using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessCommander.Models;

namespace ProcessCommander.UserData
{
    public class UserResources
    {
        public string OperatingSystemInfo { get; set; }
        public string Os { get; set; }
        public String UserName { get; set; }
        public string MachineName { get; set; }

        public UserResources()
        {
            GatherUserResourcesData();
        }

        private void GatherUserResourcesData()
        {
            this.OperatingSystemInfo = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            this.Os = Environment.OSVersion.ToString();
            this.UserName = Environment.UserName;
            this.MachineName = Environment.MachineName;
        }

        public ResourcesModel GetUserResources()
        {
            return new ResourcesModel()
            {
                OperatingSystemInfo = this.OperatingSystemInfo,
                Os = this.Os,
                UserName = this.UserName,
                MachineName =  this.MachineName  
            };
        }
    }
}

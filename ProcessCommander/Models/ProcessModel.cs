using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessCommander.Models
{
    public class ProcessModel
    {
        public string ProcessName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime TotalProcessorTime { get; set; }
//        public string RamUsage { get; set; }
//        public string CpuUsage { get; set; }
    }
}

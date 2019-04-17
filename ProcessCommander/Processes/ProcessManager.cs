using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProcessCommander.Models;

namespace ProcessCommander.Processes
{
    public class ProcessManager
    {
        public Process[] GetAllProcesses()
        {
            Process[] processes = Process.GetProcesses();
            return processes;
        }

    }
}

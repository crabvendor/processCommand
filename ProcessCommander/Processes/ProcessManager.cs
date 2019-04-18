using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using ProcessCommander.Models;

namespace ProcessCommander.Processes
{
    public class MyProcessManager
    {
        public IList<Process> GetAllAccessableProcesses()
        {
            List<Process> accessedProcesses = new List<Process>();
            foreach (var process in Process.GetProcesses())
            {
                if (IsAccessable(process))
                {
                    accessedProcesses.Add(process);
                }
            }

            return accessedProcesses;
        }

        private async Task<double> GetCpuUsageForProcess(Process process)
        {
            
            var startTime = DateTime.UtcNow;
            var startCpuUsage = process.TotalProcessorTime;
            await Task.Delay(500);

            var endTime = DateTime.UtcNow;
            var endCpuUsage = process.TotalProcessorTime;
            var cpuUsedMs = (endCpuUsage - startCpuUsage).TotalMilliseconds;
            var totalMsPassed = (endTime - startTime).TotalMilliseconds;
            var cpuUsageTotal = cpuUsedMs / (Environment.ProcessorCount * totalMsPassed);
            return cpuUsageTotal * 100;
        }
        public double getProcessCpuUsage(string processName, IList<Process> processes)
        {
            double cpuUsage = 0;
            foreach (Process process in processes)
            {
                if (process.ProcessName == processName)
                {
                    Console.WriteLine("Weszłem");
                    cpuUsage = GetCpuUsageForProcess(process).Result;
                    return cpuUsage;
                }
                else
                {
                    Console.WriteLine("Nie weszłeś");
                }
            }

            return cpuUsage;
        }

        private bool IsAccessable(Process process)
        {
            try
            {
                var processStartTime = process.StartTime;
            }
            catch (Win32Exception e)
            {
                return false;
            }
            return true;
        }
    }
}

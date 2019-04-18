using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using ProcessCommander.Models;

namespace ProcessCommander.Processes
{
    public class MyProcessManager
    {
        public void KillProcessByName(string name)
        {
            foreach (var process in Process.GetProcessesByName(name))
            {
                 process.Kill();
            }
        }
        public IList<Process> GetAccessableProcess(string name)
        {
            List<Process> accessedProcesses = new List<Process>();
            foreach (var process in Process.GetProcessesByName(name))
            {
                if (IsAccessable(process))
                {
                    accessedProcesses.Add(process);
                }
            }

            return accessedProcesses;
        }
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

        public async Task<double> GetCpuUsageForProcess(Process process)
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

        public string GetProcessRamUsage(Process process)
        {
            return $"{process.WorkingSet64}MB";
        }


        public double GetProcessCpuUsage(Process process)
        {
            return GetCpuUsageForProcess(process).Result;
        }

        private bool IsAccessable(Process process)
        {
            try
            {
                var processStartTime = process.StartTime;
            }
            catch (Win32Exception)
            {
                return false;
            }
            return true;
        }
    }
}

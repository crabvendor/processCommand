﻿using System;
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using ProcessCommander.Models;
using ProcessCommander.Processes;

namespace ProcessCommander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyProcessManager _processManager;

        public ProcessController(IMapper mapper)
        {
            _mapper = mapper;
            _processManager = new MyProcessManager();
        }

        [HttpGet]
        public ActionResult<ProcessModel[]> GetAllProcesses()
        {   
            var processes = _processManager.GetAllAccessableProcesses();
            if (processes == null) return NotFound();
            ProcessModel[] processModels = _mapper.Map<ProcessModel[]>(processes);
            return processModels;
        }
        [HttpGet("{name}")]
        public ActionResult<ProcessModel[]> GetProcessByName(string name)
        {
            var processes = _processManager.GetAccessableProcess(name);
            if (processes == null) return NotFound();
            ProcessModel[] processModels = _mapper.Map<ProcessModel[]>(processes);

            for (int i = 0; i < processes.Count; i++)
            {
                processModels[i].CpuUsage = _processManager.GetProcessCpuUsage(processes[i]);
                processModels[i].MemoryUsage = _processManager.GetProcessRamUsage(processes[i]);
            }
            return processModels;
        }

        [HttpDelete("{name}")]
        public ActionResult KillProcessByName(string name)
        {
            try
            {
               _processManager.KillProcessByName(name);
               return Ok();
            }
            catch (Win32Exception)
            {
                return BadRequest();
            }
        }

    }
}

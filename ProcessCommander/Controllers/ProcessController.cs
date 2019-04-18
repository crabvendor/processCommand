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
            foreach (ProcessModel processModel in processModels)
            {
                processModel.CpuUsage =_processManager.getProcessCpuUsage(processModel.ProcessName, processes);
                processModel.MemoryUsage = _processManager.GetRamUsageForProcess(processModel.ProcessName, processes) + " MB";
            }
            return processModels;
        }
        [HttpGet("{name}")]
        public ActionResult<ProcessModel[]> GetProcessByName(string name)
        {
            var processes = _processManager.GetAccessableProcess(name);
            if (processes == null) return NotFound();
            return _mapper.Map<ProcessModel[]>(processes);
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

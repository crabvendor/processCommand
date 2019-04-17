using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProcessCommander.Models;
using ProcessCommander.Processes;

namespace ProcessCommander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ProcessManager processManager;

        public ProcessController(IMapper mapper)
        {
            _mapper = mapper;
            processManager = new ProcessManager();
        }

        [HttpGet]
        public ActionResult<ProcessModel[]> GetAllProcesses()
        {
            var processes = processManager.GetAllProcesses();
            if (processes == null) return NotFound("Not Found");
            return Ok(_mapper.Map<ProcessModel[]>(processes));
        }

    }
}

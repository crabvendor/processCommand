using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessCommander.Models;

namespace ProcessCommander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<ResourcesModel> GetResources()
        {
            return new ResourcesModel();
        }
    }
}
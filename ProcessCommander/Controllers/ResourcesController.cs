using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessCommander.Models;
using ProcessCommander.UserData;

namespace ProcessCommander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly UserResources _resources;

        public ResourcesController()
        {
            _resources = new UserResources();
        }

        [HttpGet]
        public ActionResult<ResourcesModel> GetResources()
        {   
            return _resources.GetUserResources();
        }
    }
}
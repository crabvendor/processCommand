using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProcessCommander.Models;

namespace ProcessCommander.Profiles
{
    public class ProcessProfile : Profile
    {
        public ProcessProfile()
        {
            this.CreateMap<Process, ProcessModel>();
        }
    }
}

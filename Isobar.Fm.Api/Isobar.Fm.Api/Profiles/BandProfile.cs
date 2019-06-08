using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Isobar.Fm.Api.Profiles
{
    public class BandProfile : Profile
    {
        public BandProfile()
        {
            // Infrastructure
            CreateMap<Infrastructure.Models.Band, Core.Models.Band>();

            // Core
            CreateMap<Core.Models.Band, Infrastructure.Models.Band>();
            CreateMap<Core.Models.Band, Api.Models.Band>();

            // Api
            CreateMap<Api.Models.Band, Core.Models.Band>();

        }
    }
}

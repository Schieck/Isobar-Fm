using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Isobar.Fm.Api.Profiles
{
    public class TrackProfile : Profile
    {
        public TrackProfile()
        {
            // Infrastructure
            CreateMap<Infrastructure.Models.Track, Core.Models.Track>();

            // Core
            CreateMap<Core.Models.Track, Infrastructure.Models.Track>();
            CreateMap<Core.Models.Track, Api.Models.Track>();

            // Api
            CreateMap<Api.Models.Track, Core.Models.Track>();

        }
    }
}

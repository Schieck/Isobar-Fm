using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Isobar.Fm.Api.Profiles
{
    public class AlbumProfile : Profile
    {
        public AlbumProfile()
        {
            // Infrastructure
            CreateMap<Infrastructure.Models.Album, Core.Models.Album>();

            // Core
            CreateMap<Core.Models.Album, Infrastructure.Models.Album>();
            CreateMap<Core.Models.Album, Api.Models.Album>();

            // Api
            CreateMap<Api.Models.Album, Core.Models.Album>();

        }
    }
}

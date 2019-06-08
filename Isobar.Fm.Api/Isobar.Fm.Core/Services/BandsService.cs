using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Isobar.Fm.Core.Models;
using Isobar.Fm.Infrastructure.Interfaces;
using AutoMapper;

namespace Isobar.Fm.Core.Services
{
    public class BandsService : Interfaces.IBandsService
    {
        IBandsApiDataAdapter _bandsApiDataAdapter;
        IMapper _mapper;

        public BandsService(IBandsApiDataAdapter bandsApiDataAdapter, IMapper mapper)
        {
            _bandsApiDataAdapter = bandsApiDataAdapter;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Band>> GetBands()
        {
            IEnumerable<Band> bands = _mapper.Map<IEnumerable<Band>>(await _bandsApiDataAdapter.GetBandsAsync());

            return bands;            
        }
    }
}

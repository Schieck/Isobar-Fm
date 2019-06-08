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

        public async Task CreateBand(Band band)
        {
            Infrastructure.Models.Band mappedBand = _mapper.Map<Infrastructure.Models.Band>(band);

            await _bandsApiDataAdapter.CreateBand(mappedBand);
        }

        public async Task<Band> GetBand(string bandId)
        {
            Band band = _mapper.Map<Band>(await _bandsApiDataAdapter.GetBandAsync(bandId));

            return band;
        }

        public async Task<IEnumerable<Band>> GetBands()
        {
            IEnumerable<Band> bands = _mapper.Map<IEnumerable<Band>>(await _bandsApiDataAdapter.GetBandsAsync());

            return bands;            
        }
    }
}

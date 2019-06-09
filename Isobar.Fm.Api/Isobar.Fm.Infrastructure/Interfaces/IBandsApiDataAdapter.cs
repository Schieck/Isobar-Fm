using Isobar.Fm.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Isobar.Fm.Infrastructure.Interfaces
{
    public interface IBandsApiDataAdapter
    {
        Task<IEnumerable<Band>> GetBandsAsync();
        Task<Band> GetBandAsync(string bandId);
        Task CreateBand(Band band);
        Task UpdateBand(string bandId, Band band);
        Task DeleteBand(string bandId);
    }
}

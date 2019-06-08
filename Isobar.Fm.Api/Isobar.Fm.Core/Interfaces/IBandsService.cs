using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Isobar.Fm.Core.Interfaces
{
    public interface IBandsService
    {
        Task<IEnumerable<Models.Band>> GetBands();
    }
}

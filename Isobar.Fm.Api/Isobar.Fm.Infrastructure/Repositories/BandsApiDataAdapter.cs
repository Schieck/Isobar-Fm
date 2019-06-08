using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Isobar.Fm.Infrastructure.Models;
using System.Threading.Tasks;

namespace Isobar.Fm.Infrastructure.Repositories
{
    public class BandsApiDataAdapter : Interfaces.IBandsApiDataAdapter
    {
        private readonly HttpClient _httpClient;
        public BandsApiDataAdapter(IConfiguration configuration, HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task<IEnumerable<Band>> GetBandsAsync()
        {
            HttpResponseMessage httpResponse = await _httpClient.GetAsync("full");

            List<Band> result = new List<Band>();

            if (httpResponse.IsSuccessStatusCode)
            {
                 result = await httpResponse.Content.ReadAsAsync<List<Band>>();
            }

            return result;
        }
    }
}

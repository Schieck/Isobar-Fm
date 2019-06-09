using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Isobar.Fm.Infrastructure.Models;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Caching.Memory;
using System.Web;
using System.Linq;

namespace Isobar.Fm.Infrastructure.Repositories
{
    [ExcludeFromCodeCoverage]
    public class BandsApiDataAdapter : Interfaces.IBandsApiDataAdapter
    {
        private readonly HttpClient _httpClient;
        IMemoryCache _memoryCache;

        public BandsApiDataAdapter(IMemoryCache memoryCache, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<Band>> GetBandsAsync()
        {            
            var bandsCache = await _memoryCache.GetOrCreate<Task<IEnumerable<Models.Band>>>(
                "Bands", async context =>
                {
                    context.SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
                    context.SetPriority(CacheItemPriority.High);                    

                    using (HttpResponseMessage httpResponse = await _httpClient.GetAsync($"full"))
                    {                        
                        List<Band> result = new List<Band>();

                        if (httpResponse.IsSuccessStatusCode)
                        {
                            result = await httpResponse.Content.ReadAsAsync<List<Band>>();
                        }

                        return result;
                    }

                });

            return bandsCache;
        }

        public async Task<Band> GetBandAsync(string bandId)
        {
            var bandCache = await _memoryCache.GetOrCreate<Task<Models.Band>>(
               "Band", async context =>
               {
                   context.SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
                   context.SetPriority(CacheItemPriority.High);

                   using (HttpResponseMessage httpResponse = await _httpClient.GetAsync($"bands/{bandId}"))
                   {

                       Band result = new Band();

                       if (httpResponse.IsSuccessStatusCode)
                       {
                           result = await httpResponse.Content.ReadAsAsync<Band>();
                       }

                       return result;
                   }
               });

            return bandCache;
        }

        public async Task CreateBand(Band band)
        {
            await _httpClient.PostAsJsonAsync($"bands/", band);
            _memoryCache.Remove("Band");
            _memoryCache.Remove("Bands");
        }

        public async Task UpdateBand(string bandId, Band band)
        {
            await _httpClient.PutAsJsonAsync($"bands/{bandId}", band);
            _memoryCache.Remove("Band");
            _memoryCache.Remove("Bands");
        }

        public async Task DeleteBand(string bandId)
        {
            await _httpClient.DeleteAsync($"bands/{bandId}");
            _memoryCache.Remove("Band");
            _memoryCache.Remove("Bands");
        }
    }
}

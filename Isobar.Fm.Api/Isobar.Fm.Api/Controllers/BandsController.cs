using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Isobar.Fm.Core.Interfaces;
using AutoMapper;
using System.Diagnostics.CodeAnalysis;

namespace Isobar.Fm.Api.Controllers
{
    [ExcludeFromCodeCoverage]
    [Route("api/[controller]")]
    [ApiController]
    public class BandsController : ControllerBase
    {
        IBandsService _bandsService;
        IMapper _mapper;

        public BandsController(IBandsService bandsService, IMapper mapper)
        {
            _bandsService = bandsService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all bands with it own Albuns and Tracks of Albuns.
        /// </summary>
        /// <returns>Return a complete Band Object</returns>
        [HttpGet]
        public async Task<IEnumerable<Models.Band>> GetAsync()
        {
            var result = await _bandsService.GetBands();
            var mappedResult = _mapper.Map<IEnumerable<Models.Band>>(result);

            return mappedResult;
        }       

        /// <summary>
        /// Get the band it's id.
        /// </summary>
        /// <returns>Return a Band Object</returns>
        [HttpGet("{id}")]
        public async Task<Models.Band> Get(string id)
        {
            var result = await _bandsService.GetBand(id);
            var mappedResult = _mapper.Map<Models.Band>(result);

            return mappedResult;
        }

        /// <summary>
        /// Method to create a new full band
        /// </summary>
        /// <param name="band">Band object</param>
        /// <returns>Task with the created result</returns>
        [HttpPost]
        public async Task Post([FromBody] Models.Band band)
        {
            Core.Models.Band mappedBand = _mapper.Map<Core.Models.Band>(band);
            await _bandsService.CreateBand(mappedBand);
        }

        /// <summary>
        /// Method to update a full band
        /// </summary>
        /// <param name="id">Band Id</param>
        /// <param name="band">Band object</param>
        /// <returns>Task with the updated result</returns>
        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody]  Models.Band band)
        {
            Core.Models.Band mappedBand = _mapper.Map<Core.Models.Band>(band);
            await _bandsService.UpdateBand(id, mappedBand);
        }

        /// <summary>
        /// Method to delete a band by an Id
        /// </summary>
        /// <param name="id">Id of the band to be deleted</param>
        /// <returns>A task with the deleted result</returns>
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _bandsService.DeleteBand(id);
        }
    }
}

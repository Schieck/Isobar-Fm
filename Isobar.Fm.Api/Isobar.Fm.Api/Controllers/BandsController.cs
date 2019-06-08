using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Isobar.Fm.Core.Interfaces;
using AutoMapper;
namespace Isobar.Fm.Api.Controllers
{
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

        // GET api/bands
        [HttpGet]
        public async Task<IEnumerable<Models.Band>> GetAsync()
        {
            var result = await _bandsService.GetBands();
            var mappedResult = _mapper.Map<IEnumerable<Models.Band>>(result);

            return mappedResult;
        }

        // GET api/bands/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/bands
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/bands/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/bands/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

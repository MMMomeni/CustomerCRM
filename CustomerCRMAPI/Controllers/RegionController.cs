using CustomerCRM.Core.Contracts.Service;
using CustomerCRM.Core.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerCRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionServiceAsync regionServiceAsync;
        public RegionController(IRegionServiceAsync regionServiceAsync)
        {
            this.regionServiceAsync = regionServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await regionServiceAsync.GetAllRegions();
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post(RegionModel region)
        {
            if(await regionServiceAsync.InsertRegion(region) > 0)
                return Ok(region);
            return BadRequest();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Put(int id, RegionModel region)
        {
             if(id == region.Id & ModelState.IsValid)
            {
                if (await regionServiceAsync.UpdateRegion(region) > 0)
                    return Ok(region);
            }
             return BadRequest();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(await regionServiceAsync.DeleteRegion(id) > 0)
            {
                /*we should send even the messages as json objects*/
                var msg = new { Message = "Region has been deleted successfully" };
                return Ok(msg);
            }
                
            return BadRequest();
        }
    }
}

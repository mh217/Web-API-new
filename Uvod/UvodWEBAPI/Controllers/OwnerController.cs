using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Uvod.Model;
using Uvod.Service;
using Uvod.Service.Common;



namespace UvodWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwnerAsync(Owner owner)
        { 
            var ownerFound = await _ownerService.CreateOwnerServiceAsync(owner);
            if (ownerFound == false) 
            {
                return BadRequest("Not found");
            }
            return Ok("Owner Added");
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteOwnerByIdAsync(Guid id)
        {
            var ownerFound = await _ownerService.DeleteOwnerServiceAsync(id);
            if (ownerFound == false)
            {
                return BadRequest("Not found");
            }
            return Ok("Owner deleted");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateOwnerAsync(Guid id, [FromBody] Owner owner)
        {
            var ownerFound = await _ownerService.UpdateOwnerAsync(id, owner);
            if (ownerFound == false)
            {
                return BadRequest("Not found");
            }
            return Ok("Owner updated");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOwnerByIdAsync(Guid id)
        {
            var foundOwner = await _ownerService.GetOwnerByIdServiceAsync(id);
            if (foundOwner is null)
            {
                return BadRequest("Not found");
            }
            return Ok(foundOwner);
        }


        [HttpGet]

        public async Task<IActionResult> GetOwnersAsync()
        {
            var foundOwners = await _ownerService.GetOwnersServiceAsync();
            if (foundOwners is null)
            {
                return BadRequest("Not found");
            }
            return Ok(foundOwners);
        }
    }
}

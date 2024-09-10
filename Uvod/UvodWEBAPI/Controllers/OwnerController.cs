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
            var isOwnerCreated = await _ownerService.CreateOwnerServiceAsync(owner);
            if (!isOwnerCreated) 
            {
                return BadRequest("Not found");
            }
            return Ok("Owner Added");
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteOwnerByIdAsync(Guid id)
        {
            var isOwnerDeleted = await _ownerService.DeleteOwnerServiceAsync(id);
            if (!isOwnerDeleted)
            {
                return BadRequest("Not found");
            }
            return Ok("Owner deleted");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateOwnerAsync(Guid id, [FromBody] Owner owner)
        {
            var isOwnerUpdated = await _ownerService.UpdateOwnerAsync(id, owner);
            if (!isOwnerUpdated)
            {
                return BadRequest("Not found");
            }
            return Ok("Owner updated");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOwnerByIdAsync(Guid id)
        {
            var isOwnerFound = await _ownerService.GetOwnerByIdServiceAsync(id);
            if (isOwnerFound is null)
            {
                return BadRequest("Not found");
            }
            return Ok(isOwnerFound);
        }


        [HttpGet]

        public async Task<IActionResult> GetOwnersAsync()
        {
            var isOwnerFound = await _ownerService.GetOwnersServiceAsync();
            if (isOwnerFound is null)
            {
                return BadRequest("Not found");
            }
            return Ok(isOwnerFound);
        }
    }
}

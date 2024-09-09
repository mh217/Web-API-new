using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Uvod.Model;
using Uvod.Service;



namespace UvodWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        
        [HttpPost]
        public async Task<IActionResult> CreateOwnerAsync(Owner owner)
        {
            OwnerService service = new OwnerService(); 
            var ownerFound = await service.CreateOwnerServiceAsync(owner);
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
            OwnerService service = new OwnerService();
            var ownerFound = await service.DeleteOwnerServiceAsync(id);
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
            OwnerService service = new OwnerService();
            var ownerFound = await service.UpdateOwnerAsync(id, owner);
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
            OwnerService service = new OwnerService();
            var foundOwner = await service.GetOwnerByIdServiceAsync(id);
            if (foundOwner is null)
            {
                return BadRequest("Not found");
            }
            return Ok(foundOwner);
        }


        [HttpGet]

        public async Task<IActionResult> GetOwnersAsync()
        {
            OwnerService service = new OwnerService();
            var foundOwners = await service.GetOwnersServiceAsync();
            if (foundOwners is null)
            {
                return BadRequest("Not found");
            }
            return Ok(foundOwners);
        }
    }
}

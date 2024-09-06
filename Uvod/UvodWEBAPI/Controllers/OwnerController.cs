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
        public IActionResult CreateOwner(Owner owner)
        {
            OwnerService service = new OwnerService(); 
            var ownerFound = service.CreateOwnerService(owner);
            if (ownerFound == false) 
            {
                return BadRequest("Not found");
            }
            return Ok("Owner Added");
            
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteOwnerById(Guid id)
        {
            OwnerService service = new OwnerService();
            var ownerFound = service.DeleteOwnerService(id);
            if (ownerFound == false)
            {
                return BadRequest("Not found");
            }
            return Ok("Owner deleted");
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateOwner(Guid id, [FromBody] Owner owner)
        {
            OwnerService service = new OwnerService();
            var ownerFound = service.UpdateOwner(id, owner);
            if (ownerFound == false)
            {
                return BadRequest("Not found");
            }
            return Ok("Owner updated");
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOwnerById(Guid id)
        {
            OwnerService service = new OwnerService();
            var foundOwner = service.GetOwnerByIdService(id);
            if (foundOwner is null)
            {
                return BadRequest("Not found");
            }
            return Ok(foundOwner);
        }


        [HttpGet]

        public IActionResult GetOwners()
        {
            OwnerService service = new OwnerService();
            var foundOwners = service.GetOwnersService();
            if (foundOwners is null)
            {
                return BadRequest("Not found");
            }
            return Ok(foundOwners);
        }
    }
}

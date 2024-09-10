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
    public class AnimalController : ControllerBase
    {
        private IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        
        


        [HttpPost]
        public async Task<IActionResult> CreateAnimalsAsync(Animal animal)
        {
            var isAnimalCreated = await _animalService.CreateAnimalServiceAsync(animal);
            if (!isAnimalCreated)
            {
                return BadRequest("Not found");
            }
            return Ok("Animal Added");
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAnimalByIdAsync(Guid id)
        {
            var isAnimalDeleted = await _animalService.DeleteAnimalServiceAsync(id);
            if (!isAnimalDeleted)
            {
                return BadRequest("Not found");
            }
            return Ok("Animal Added");
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAnimalAsync(Guid id, [FromBody] AnimalUpdate animal)
        {
            var isAnimalUpdated = await _animalService.UpdateAnimalAsync(id, animal);
            if (!isAnimalUpdated)
            {
                return BadRequest("Not found");
            }
            return Ok("Animal updated");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAnimalByIdAsync(Guid id)
        {
            
            var animal = await _animalService.GetAnimalByIdServiceAsync(id);
            if (animal is null)
            {
                return BadRequest("Not found");
            }
            return Ok(animal);
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimalsAsync()
        {
            var animals = await _animalService.GetAllAnimalsAsync();
            if (animals is null)
            {
                return BadRequest("Not found");
            }
            return Ok(animals);
        }


    }
}

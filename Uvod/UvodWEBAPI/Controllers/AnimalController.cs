using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Uvod.Model;
using Uvod.Service;



namespace UvodWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {

        
        private static List<Animal> _animals = new List<Animal>();


        [HttpPost]
        public async Task<IActionResult> CreateAnimalsAsync(Animal animal)
        {
            AnimalService service = new AnimalService();
            var animalFound = await service.CreateAnimalServiceAsync(animal);
            if (animalFound == false)
            {
                return BadRequest("Not found");
            }
            return Ok("Animal Added");
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAnimalByIdAsync(Guid id)
        {
            AnimalService service = new AnimalService();
            var animalFound = await service.DeleteAnimalServiceAsync(id);
            if (animalFound == false)
            {
                return BadRequest("Not found");
            }
            return Ok("Animal Added");
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAnimalAsync(Guid id, [FromBody] AnimalUpdate animal)
        {
            AnimalService service = new AnimalService();
            var animalFound = await service.UpdateAnimalAsync(id, animal);
            if (animalFound == false)
            {
                return BadRequest("Not found");
            }
            return Ok("Animal updated");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAnimalByIdAsync(Guid id)
        {
            AnimalService service = new AnimalService();
            var animal = await service.GetAnimalByIdServiceAsync(id);
            if (animal is null)
            {
                return BadRequest("Not found");
            }
            return Ok(animal);
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimalsAsync()
        {
            AnimalService service = new AnimalService();
            var animals = await service.GetAllAnimalsAsync();
            if (animals is null)
            {
                return BadRequest("Not found");
            }
            return Ok(animals);
        }


    }
}

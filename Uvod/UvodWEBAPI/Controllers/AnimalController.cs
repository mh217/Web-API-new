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
        public IActionResult CreateAnimals(Animal animal)
        {
            AnimalService service = new AnimalService();
            var animalFound = service.CreateAnimalService(animal);
            if (animalFound == false)
            {
                return BadRequest("Not found");
            }
            return Ok("Animal Added");
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteAnimalById(Guid id)
        {
            AnimalService service = new AnimalService();
            var animalFound = service.DeleteAnimalService(id);
            if (animalFound == false)
            {
                return BadRequest("Not found");
            }
            return Ok("Animal Added");
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateAnimal(Guid id, [FromBody] AnimalUpdate animal)
        {
            AnimalService service = new AnimalService();
            var animalFound = service.UpdateAnimal(id, animal);
            if (animalFound == false)
            {
                return BadRequest("Not found");
            }
            return Ok("Animal updated");
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAnimalById(Guid id)
        {
            AnimalService service = new AnimalService();
            var animal = service.GetAnimalByIdService(id);
            if (animal is null)
            {
                return BadRequest("Not found");
            }
            return Ok(animal);
        }

        [HttpGet]
        public IActionResult GetAnimals()
        {
            AnimalService service = new AnimalService();
            var animals = service.GetAllAnimals();
            if (animals is null)
            {
                return BadRequest("Not found");
            }
            return Ok(animals);
        }


    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Uvod.Common;
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
        public async Task<IActionResult> GetAnimalsAsync(string orderBy = "Name", string orderDirection = "DESC", int rpp = 4, int pageNumber = 1, 
            string animalName = "", string specise = "", int ageMin = 0, int ageMax = 0, DateTime? dateOfBirthMax = null, DateTime? dateOfBirthMin = null, string name = "")
        {
            Sorting sort = new Sorting();
            sort.OrderBy = orderBy;
            sort.OrderDirection = orderDirection;
            Paging paging = new Paging();
            paging.PageNumber = pageNumber;
            paging.Rpp = rpp;
            AnimalFilter filter = new AnimalFilter();
            filter.NameQuery = animalName;
            filter.SpeciesQuery = specise;
            filter.AgeMin = ageMin;
            filter.AgeMax = ageMax;
            filter.DateOfBirthMax = dateOfBirthMax;
            filter.DateOfBirthMin = dateOfBirthMin;
            filter.Owner = name; 
            var animals = await _animalService.GetAllAnimalsAsync(sort, paging, filter);
            if (animals is null)
            {
                return BadRequest("Not found");
            }
            return Ok(animals);
        }


    }
}

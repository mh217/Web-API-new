using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uvod.Model;
using Uvod.Repository;
using Uvod.Service.Common;

namespace Uvod.Service
{
    public class AnimalService : IAnimalService
    {

        public async Task<bool> CreateAnimalServiceAsync(Animal animal)
        {
            AnimalRepository repository = new AnimalRepository();
            var animalFound = await repository.CreateAnimalAsync(animal);
            if(animalFound == false)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteAnimalServiceAsync(Guid id) 
        {
            AnimalRepository repository = new AnimalRepository();
            var animalFound = await repository.DeleteAnimalAsync(id);
            if (animalFound == false)
            {
                return false;
            }
            return true;
        }

        public async Task<Animal> GetAnimalByIdServiceAsync(Guid id)
        {
            AnimalRepository repository = new AnimalRepository();
            var animal = await repository.GetAnimalByIdAsync(id);
            if (animal == null)
            {
                return null;
            }
            return animal;
        }

        public async Task<List<Animal>> GetAllAnimalsAsync() 
        {
            AnimalRepository repository = new AnimalRepository();
            var foundAnimals = await repository.GetAnimalsAsync();
            if (foundAnimals == null)
            {
                return null;
            }
            return foundAnimals;
        }

        public async Task<bool> UpdateAnimalAsync(Guid id, AnimalUpdate animal)
        {
            AnimalRepository repository = new AnimalRepository();
            var foundAnimal = await repository.GetAnimalByIdAsync(id);
            if (foundAnimal == null)
            {
                return false;
            }
            return await repository.UpdateAnimalAsync(id, animal);
        }
    }
}

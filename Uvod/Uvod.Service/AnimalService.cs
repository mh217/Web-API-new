using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uvod.Common;
using Uvod.Model;
using Uvod.Repository;
using Uvod.Repository.Common;
using Uvod.Service.Common;

namespace Uvod.Service
{
    public class AnimalService : IAnimalService
    {
        private IAnimalRepository _animalRepository;
        
        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<bool> CreateAnimalServiceAsync(Animal animal)
        {
            var isAnimalCreated = await _animalRepository.CreateAnimalAsync(animal);
            if(!isAnimalCreated)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteAnimalServiceAsync(Guid id) 
        {
            var isAnimalDeleted = await _animalRepository.DeleteAnimalAsync(id);
            if (!isAnimalDeleted)
            {
                return false;
            }
            return true;
        }

        public async Task<Animal> GetAnimalByIdServiceAsync(Guid id)
        {
            var animal = await _animalRepository.GetAnimalByIdAsync(id);
            if (animal == null)
            {
                return null;
            }
            return animal;
        }

        public async Task<List<Animal>> GetAllAnimalsAsync(Sorting sort, Paging paging, AnimalFilter filter) 
        {
            var foundAnimals = await _animalRepository.GetAnimalsAsync(sort, paging, filter);
            if (foundAnimals == null)
            {
                return null;
            }
            return foundAnimals;
        }

        public async Task<bool> UpdateAnimalAsync(Guid id, AnimalUpdate animal)
        {
            var foundAnimal = await _animalRepository.GetAnimalByIdAsync(id);
            if (foundAnimal == null)
            {
                return false;
            }
            return await _animalRepository.UpdateAnimalAsync(id, animal);
        }
    }
}

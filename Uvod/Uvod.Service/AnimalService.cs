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

        public bool CreateAnimalService(Animal animal)
        {
            AnimalRepository repository = new AnimalRepository();
            var animalFound = repository.CreateAnimal(animal);
            if(animalFound == false)
            {
                return false;
            }
            return true;
        }

        public bool DeleteAnimalService(Guid id) 
        {
            AnimalRepository repository = new AnimalRepository();
            var animalFound = repository.DeleteAnimal(id);
            if (animalFound == false)
            {
                return false;
            }
            return true;
        }

        public Animal GetAnimalByIdService(Guid id)
        {
            AnimalRepository repository = new AnimalRepository();
            var animal = repository.GetAnimalById(id);
            if (animal == null)
            {
                return null;
            }
            return animal;
        }

        public List<Animal> GetAllAnimals() 
        {
            AnimalRepository repository = new AnimalRepository();
            var foundAnimals = repository.GetAnimals();
            if (foundAnimals == null)
            {
                return null;
            }
            return foundAnimals;
        }

        public bool UpdateAnimal(Guid id, AnimalUpdate animal)
        {
            AnimalRepository repository = new AnimalRepository();
            var foundAnimal = repository.GetAnimalById(id);
            if (foundAnimal == null)
            {
                return false;
            }
            return repository.UpdateAnimal(id, animal);
        }
    }
}

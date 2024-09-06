using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uvod.Model;

namespace Uvod.Service.Common
{
    public interface IAnimalService
    {
        public bool CreateAnimalService(Animal animal);
        public bool DeleteAnimalService(Guid id);
        public Animal GetAnimalByIdService(Guid id);
        public List<Animal> GetAllAnimals();
        public bool UpdateAnimal(Guid id, AnimalUpdate animal);
    }
}

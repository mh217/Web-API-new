using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uvod.Model;

namespace Uvod.Repository.Common
{
    public interface IAnimalRepository
    {
        public bool CreateAnimal(Animal animal);
        public bool DeleteAnimal(Guid id);
        public Animal GetAnimalById(Guid id);
        public List<Animal> GetAnimals();
        public bool UpdateAnimal(Guid id, AnimalUpdate animal);
    }
}

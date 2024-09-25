using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uvod.Common;
using Uvod.Model;

namespace Uvod.Repository.Common
{
    public interface IAnimalRepository
    {
        public Task<bool> CreateAnimalAsync(Animal animal);
        public Task<bool> DeleteAnimalAsync(Guid id);
        public Task<Animal> GetAnimalByIdAsync(Guid id);
        public Task<List<Animal>> GetAnimalsAsync(Sorting sort, Paging paging, AnimalFilter filter);
        public Task<bool> UpdateAnimalAsync(Guid id, Animal animal);
        public Task<List<Animal>> GetAllAnimalsAsync();
    }
}

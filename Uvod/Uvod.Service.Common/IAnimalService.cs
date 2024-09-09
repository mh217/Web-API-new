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
        public Task<bool> CreateAnimalServiceAsync(Animal animal);
        public Task<bool> DeleteAnimalServiceAsync(Guid id);
        public Task<Animal> GetAnimalByIdServiceAsync(Guid id);
        public Task<List<Animal>> GetAllAnimalsAsync();
        public Task<bool> UpdateAnimalAsync(Guid id, AnimalUpdate animal);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uvod.Model;

namespace Uvod.Repository.Common
{
    public interface IOwnerRepository
    {
        public Task<bool> CreateOwnerAsync(Owner owner);
        public Task<bool> DeleteOwnerAsync(Guid id);
        public Task<Owner> GetOwnerByIdAsync(Guid id);
        public Task<List<Owner>> GetOwnersAsync();
        public Task<bool> UpdateOwnerAsync(Guid id, Owner owner);
    }
}

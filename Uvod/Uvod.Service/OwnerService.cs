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
    public class OwnerService : IOwnerService
    {
        public async Task<bool> CreateOwnerServiceAsync(Owner owner)
        {
            OwnerRepository repository = new OwnerRepository();
            var ownerFound = await repository.CreateOwnerAsync(owner);
            if (ownerFound == false)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteOwnerServiceAsync(Guid id) 
        {
            OwnerRepository repository = new OwnerRepository();
            var ownerFound = await repository.DeleteOwnerAsync(id);
            if (ownerFound == false)
            {
                return false;
            }
            return true;
        }

        public async Task<Owner> GetOwnerByIdServiceAsync(Guid id)
        {
            OwnerRepository repository = new OwnerRepository();
            var foundOwner = await repository.GetOwnerByIdAsync(id);
            if(foundOwner == null)
            {
                return null;
            }
            return foundOwner;
        }

        public async Task<List<Owner>> GetOwnersServiceAsync() 
        {
            OwnerRepository repository = new OwnerRepository();
            var foundOwners = await repository.GetOwnersAsync();
            if(foundOwners == null)
            {
                return null;
            }
            return foundOwners;
        }

        public async Task<bool> UpdateOwnerAsync(Guid id, Owner owner) 
        {
            OwnerRepository repository = new OwnerRepository();
            var foundOwners = await repository.GetOwnerByIdAsync(id);
            if (foundOwners == null)
            {
                return false;
            }
            return await repository.UpdateOwnerAsync(id, owner);
        }

    }
}

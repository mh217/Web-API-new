using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uvod.Model;
using Uvod.Repository;
using Uvod.Repository.Common;
using Uvod.Service.Common;

namespace Uvod.Service
{
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository _ownerRepository; 
        
        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<bool> CreateOwnerServiceAsync(Owner owner)
        {
            var ownerFound = await _ownerRepository.CreateOwnerAsync(owner);
            if (ownerFound == false)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteOwnerServiceAsync(Guid id) 
        {
            var ownerFound = await _ownerRepository.DeleteOwnerAsync(id);
            if (ownerFound == false)
            {
                return false;
            }
            return true;
        }

        public async Task<Owner> GetOwnerByIdServiceAsync(Guid id)
        {
            var foundOwner = await _ownerRepository.GetOwnerByIdAsync(id);
            if(foundOwner == null)
            {
                return null;
            }
            return foundOwner;
        }

        public async Task<List<Owner>> GetOwnersServiceAsync() 
        {
            var foundOwners = await _ownerRepository.GetOwnersAsync();
            if(foundOwners == null)
            {
                return null;
            }
            return foundOwners;
        }

        public async Task<bool> UpdateOwnerAsync(Guid id, Owner owner) 
        {
            var foundOwners = await _ownerRepository.GetOwnerByIdAsync(id);
            if (foundOwners == null)
            {
                return false;
            }
            return await _ownerRepository.UpdateOwnerAsync(id, owner);
        }

    }
}

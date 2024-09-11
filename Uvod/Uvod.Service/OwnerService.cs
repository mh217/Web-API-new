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
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository _ownerRepository; 
        
        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<bool> CreateOwnerServiceAsync(Owner owner)
        {
            var isOwnerCreated = await _ownerRepository.CreateOwnerAsync(owner);
            if (!isOwnerCreated)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteOwnerServiceAsync(Guid id) 
        {
            var isOwnerDeleted = await _ownerRepository.DeleteOwnerAsync(id);
            if (!isOwnerDeleted)
            {
                return false;
            }
            return true;
        }

        public async Task<Owner> GetOwnerByIdServiceAsync(Guid id)
        {
            var isOwnerFound = await _ownerRepository.GetOwnerByIdAsync(id);
            if(isOwnerFound == null)
            {
                return null;
            }
            return isOwnerFound;
        }

        public async Task<List<Owner>> GetOwnersServiceAsync(Sorting sort, Paging paging, OwnerFilter filter) 
        {
            var areOwnersFound = await _ownerRepository.GetOwnersAsync(sort, paging, filter);
            if(areOwnersFound == null)
            {
                return null;
            }
            return areOwnersFound;
        }

        public async Task<bool> UpdateOwnerAsync(Guid id, Owner owner) 
        {
            var isOwnerFound = await _ownerRepository.GetOwnerByIdAsync(id);
            if (isOwnerFound == null)
            {
                return false;
            }
            return await _ownerRepository.UpdateOwnerAsync(id, owner);
        }

    }
}

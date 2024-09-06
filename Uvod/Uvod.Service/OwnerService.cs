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
        public bool CreateOwnerService(Owner owner)
        {
            OwnerRepository repository = new OwnerRepository();
            var ownerFound = repository.CreateOwner(owner);
            if (ownerFound == false)
            {
                return false;
            }
            return true;
        }

        public bool DeleteOwnerService(Guid id) 
        {
            OwnerRepository repository = new OwnerRepository();
            var ownerFound = repository.DeleteOwner(id);
            if (ownerFound == false)
            {
                return false;
            }
            return true;
        }

        public Owner GetOwnerByIdService(Guid id)
        {
            OwnerRepository repository = new OwnerRepository();
            var foundOwner = repository.GetOwnerById(id);
            if(foundOwner == null)
            {
                return null;
            }
            return foundOwner;
        }

        public List<Owner> GetOwnersService() 
        {
            OwnerRepository repository = new OwnerRepository();
            var foundOwners = repository.GetOwners();
            if(foundOwners == null)
            {
                return null;
            }
            return foundOwners;
        }

        public bool UpdateOwner(Guid id, Owner owner) 
        {
            OwnerRepository repository = new OwnerRepository();
            var foundOwners = repository.GetOwnerById(id);
            if (foundOwners == null)
            {
                return false;
            }
            return repository.UpdateOwner(id, owner);
        }

    }
}

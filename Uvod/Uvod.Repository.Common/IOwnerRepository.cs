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
        public bool CreateOwner(Owner owner);
        public bool DeleteOwner(Guid id);
        public Owner GetOwnerById(Guid id);
        public List<Owner> GetOwners();
        public bool UpdateOwner(Guid id, Owner owner);
    }
}

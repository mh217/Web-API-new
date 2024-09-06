using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uvod.Model;

namespace Uvod.Service.Common
{
    public interface IOwnerService
    {
        public bool CreateOwnerService(Owner owner);
        public bool DeleteOwnerService(Guid id);
        public Owner GetOwnerByIdService(Guid id);
        public List<Owner> GetOwnersService();
        public bool UpdateOwner(Guid id, Owner owner);
    }
}

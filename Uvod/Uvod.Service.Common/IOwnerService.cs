using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uvod.Common;
using Uvod.Model;

namespace Uvod.Service.Common
{
    public interface IOwnerService
    {
        public Task<bool> CreateOwnerServiceAsync(Owner owner);
        public Task<bool> DeleteOwnerServiceAsync(Guid id);
        public Task<Owner> GetOwnerByIdServiceAsync(Guid id);
        public Task<List<Owner>> GetOwnersServiceAsync(Sorting sort, Paging paging, OwnerFilter filter);
        public Task<bool> UpdateOwnerAsync(Guid id, Owner owner);
    }
}

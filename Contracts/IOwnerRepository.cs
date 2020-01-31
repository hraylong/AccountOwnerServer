using AccountOwner.DataAccessLayer;
using System;
using System.Dynamic;

namespace AccountOwner.Contracts
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
        PagedList<ExpandoObject> GetOwners(OwnerParameters ownerParameters);
        ExpandoObject GetOwnerById(Guid ownerId, string fields);
        Owner GetOwnerById(Guid ownerId);
        Owner GetOwnerWithDetails(Guid ownerId);
        void CreateOwner(Owner owner);
        void UpdateOwner(Owner owner);

        void DeleteOwner(Owner owner);
    }
}

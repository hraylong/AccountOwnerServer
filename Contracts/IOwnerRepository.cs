using AccountOwner.DataAccessLayer;
using System;
using System.Collections.Generic;

namespace AccountOwner.Contracts
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
        IEnumerable<Owner> GetAllOwners();
        Owner GetOwnerById(Guid ownerId);
        Owner GetOwnerWithDetails(Guid ownerId);
        void CreateOwner(Owner owner);
        void UpdateOwner(Owner owner);

        void DeleteOwner(Owner owner);
    }
}

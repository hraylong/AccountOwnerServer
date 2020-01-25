using AccountOwner.Contracts;
using AccountOwner.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountOwner.Repository
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}

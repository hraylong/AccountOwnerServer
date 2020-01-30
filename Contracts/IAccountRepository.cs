using AccountOwner.DataAccessLayer;
using System;
using System.Collections.Generic;

namespace AccountOwner.Contracts
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        IEnumerable<Account> AccountsByOwner(Guid ownerId);
    }
}

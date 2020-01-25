using AccountOwner.Contracts;
using AccountOwner.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountOwner.Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}

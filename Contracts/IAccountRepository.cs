using AccountOwner.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace AccountOwner.Contracts
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        IEnumerable<Account> AccountsByOwner(Guid ownerId);
        PagedList<Account> GetAccountsByOwner(Guid ownerId, AccountParameters accountParameters);
        Account GetAccountByOwner(Guid ownerId, Guid id);
        PagedList<ExpandoObject> GetAccounts(AccountParameters accountParameters);
        ExpandoObject GetAccountById(Guid accountId, string fields);
        Account GetAccountById(Guid accountId);
        void CreateAccount(Account account);
        void UpdateAccount(Account account);
        void DeleteAccount(Account account);
    }
}

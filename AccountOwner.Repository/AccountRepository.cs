using AccountOwner.Contracts;
using AccountOwner.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace AccountOwner.Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        private ISortHelper<Account> _sortHelper;
        private IDataShaper<Account> _dataShaper;

        private void SearchByAccountType(ref IQueryable<Account> accounts, string accountType)
        {
            if (!accounts.Any() || string.IsNullOrWhiteSpace(accountType))
                return;

            accounts = accounts.Where(o => o.AccountType.ToLower().Contains(accountType.Trim().ToLower()));
        }

        public AccountRepository(RepositoryContext repositoryContext
            , ISortHelper<Account> sortHelper
            , IDataShaper<Account> dataShaper)
            : base(repositoryContext)
        {
            _sortHelper = sortHelper;
            _dataShaper = dataShaper;
        }

        public IEnumerable<Account> AccountsByOwner(Guid ownerId)
        {
            return FindByCondition(a => a.OwnerId.Equals(ownerId)).ToList();
        }

        public PagedList<Account> GetAccountsByOwner(Guid ownerId, AccountParameters parameters)
        {
            var accounts = FindByCondition(a => a.OwnerId.Equals(ownerId));

            return PagedList<Account>.ToPagedList(accounts,
                parameters.PageNumber,
                parameters.PageSize);
        }

        public Account GetAccountByOwner(Guid ownerId, Guid id)
        {
            return FindByCondition(a => a.OwnerId.Equals(ownerId) && a.Id.Equals(id)).SingleOrDefault();
        }

        public PagedList<ExpandoObject> GetAccounts(AccountParameters accountParameters)
        {
            var accounts = FindByCondition(o => o.DateCreated.Year >= accountParameters.MinYearCreated &&
                                o.DateCreated.Year <= accountParameters.MaxYearCreated);

            SearchByAccountType(ref accounts, accountParameters.AccountType);

            _sortHelper.ApplySort(accounts, accountParameters.OrderBy);
            var shapedAccounts = _dataShaper.ShapeData(accounts, accountParameters.Fields);

            return PagedList<ExpandoObject>.ToPagedList(shapedAccounts,
                accountParameters.PageNumber,
                accountParameters.PageSize);

        }

        public Account GetAccountById(Guid accountId)
        {
            return FindByCondition(account => account.Id.Equals(accountId)).FirstOrDefault();
        }

        public ExpandoObject GetAccountById(Guid accountId, string fields)
        {
            var account = FindByCondition(account => account.Id.Equals(accountId))
                .DefaultIfEmpty(new Account())
                .FirstOrDefault();

            return _dataShaper.ShapeData(account, fields);
        }

        public void CreateAccount(Account account)
        {
            Create(account);
        }

        public void UpdateAccount(Account account)
        {
            Update(account);
        }

        public void DeleteAccount(Account account)
        {
            Delete(account);
        }
    }
}

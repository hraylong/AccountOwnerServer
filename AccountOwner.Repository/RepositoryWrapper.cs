using AccountOwner.Contracts;
using AccountOwner.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountOwner.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IOwnerRepository _owner;
        private IAccountRepository _account;
        private ISortHelper<Owner> _ownerSortHelper;
        private ISortHelper<Account> _accountSortHelper;
        private IDataShaper<Owner> _ownerDataShaper;
        private IDataShaper<Account> _accountDataShaper;

        public IOwnerRepository Owner
        {
            get
            {
                if (_owner == null)
                {
                    _owner = new OwnerRepository(_repoContext
                        , _ownerSortHelper
                        , _ownerDataShaper);
                }

                return _owner;
            }
        }

        public IAccountRepository Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(_repoContext
                        , _accountSortHelper
                        , _accountDataShaper
                        );
                }

                return _account;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext,
            ISortHelper<Owner> ownerSortHelper,
            IDataShaper<Owner> ownerDataShaper,
            ISortHelper<Account> accountSortHelper,
            IDataShaper<Account> accountDataShaper)
        {
            _repoContext = repositoryContext;
            _ownerSortHelper = ownerSortHelper;
            _accountSortHelper = accountSortHelper;
            _ownerDataShaper = ownerDataShaper;
            _accountDataShaper = accountDataShaper;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}

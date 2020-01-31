using AccountOwner.Contracts;
using AccountOwner.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AccountOwner.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            var queryReturn = this.RepositoryContext.Set<T>().AsNoTracking();
            return queryReturn;
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            var queryReturn = this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
            return queryReturn;
        }

        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }
    }
}

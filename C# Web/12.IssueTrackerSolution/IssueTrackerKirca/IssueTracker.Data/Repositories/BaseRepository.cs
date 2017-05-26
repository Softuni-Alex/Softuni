using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Data.Repositories
{
    using System.Data.Entity;
    using System.Linq.Expressions;
    using Contracts;

    public abstract class BaseRepository<T> 
        where T : class 
    {
        protected IDbSet<T> entityTable;

        protected BaseRepository(IIssuesContext dbContext)
        {
            this.entityTable = dbContext.Set<T>();
        }

        public void Insert(T entity)
        {
            this.entityTable.Add(entity);
        }

        public void Delete(T entity)
        {
            this.entityTable.Remove(entity);
        }

        public T Find(object id)
        {
            return this.entityTable.Find(id);
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return this.entityTable.FirstOrDefault(predicate);
        }

        public IQueryable<T> All()
        {
            return this.entityTable;
        }

        public IQueryable<T> All(Expression<Func<T, bool>> expression)
        {
            return this.entityTable.Where(expression);
        }
    }
}

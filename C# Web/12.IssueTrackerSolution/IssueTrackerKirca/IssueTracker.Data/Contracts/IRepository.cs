namespace IssueTracker.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Linq.Expressions;

    public interface IRepository<T>
    {
        void Insert(T entity);

        void Delete(T entity);

        T Find(object id);

        T Find(Expression<Func<T, bool>> predicate);

        IQueryable<T> All();

        IQueryable<T> All(Expression<Func<T, bool>> expression);
    }
}

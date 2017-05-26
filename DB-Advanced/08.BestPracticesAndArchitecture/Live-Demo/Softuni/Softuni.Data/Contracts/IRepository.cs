using System;
using System.Collections.Generic;

namespace Softuni.Data.Contracts
{
    using System.Linq.Expressions;

    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void Delete(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entitites);

        TEntity GetById(int id);

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where);

        TEntity Single(Expression<Func<TEntity, bool>> where);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> where);
    }
}

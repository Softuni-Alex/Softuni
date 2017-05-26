﻿using DbEntities;
using System.Linq;

namespace RepositoryLayer.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> Query();

        T Find(object id);

        void Add(T entity);

        void Dispose(IssueTrackerContext context);

        void Update(T entity);

        void Delete(T entity);

        int SaveChanges();
    }
}
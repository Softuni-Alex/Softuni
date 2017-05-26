using DbEntities;
using RepositoryLayer.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace RepositoryLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SoftuniStoreContext context;
        private readonly DbSet<T> set;

        public Repository(SoftuniStoreContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> Query()
        {
            return this.set.AsQueryable();
        }

        public T Find(object id)
        {
            return this.set.Find(id);
        }

        public void Add(T entity)
        {
            this.set.Add(entity);
        }

        public void AddOrUpdate(T entity)
        {
            this.set.AddOrUpdate(entity);
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public void Dispose(SoftuniStoreContext context)
        {
            if (context != null)
            {
                context.Dispose();
                context = null;
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}

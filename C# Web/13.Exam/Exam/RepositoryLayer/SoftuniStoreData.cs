using DbEntities;
using DbEntities.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace RepositoryLayer
{
    public class SoftuniStoreData : ISoftuniStoreData
    {
        private readonly SoftuniStoreContext context;
        private readonly IDictionary<Type, object> repositories;

        public SoftuniStoreData()
            : this(new SoftuniStoreContext())
        {

        }

        public SoftuniStoreData(SoftuniStoreContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> User
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Game> Games
        {
            get
            {
                return this.GetRepository<Game>();
            }
        }

        public IRepository<Login> Logins
        {
            get
            {
                return this.GetRepository<Login>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public int ExecuteSqlCommand(string command)
        {
            return this.context.Database.ExecuteSqlCommand(command);
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);

            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(Repository<T>);
                var repository = Activator.CreateInstance(typeOfRepository, this.context);

                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}

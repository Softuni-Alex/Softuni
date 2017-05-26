using DbEntities;
using DbEntities.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace RepositoryLayer
{
    public class IssueTrackerData : IIssueTrackerData
    {
        private readonly IssueTrackerContext context;
        private readonly IDictionary<Type, object> repositories;

        public IssueTrackerData()
            : this(new IssueTrackerContext())
        {

        }

        public IssueTrackerData(IssueTrackerContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Issue> Issue
        {
            get
            {
                return this.GetRepository<Issue>();
            }
        }

        public IRepository<User> User
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Status> Status
        {
            get
            {
                return this.GetRepository<Status>();
            }
        }

        public IRepository<Role> Role
        {
            get
            {
                return this.GetRepository<Role>();
            }
        }

        public IRepository<Priority> Priority
        {
            get
            {
                return this.GetRepository<Priority>();
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

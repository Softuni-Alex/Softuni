namespace IssueTracker.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Contracts;
    using Models;

    public class IssuesContext : DbContext, IIssuesContext
    {
        public IssuesContext()
            : base("name=IssuesContext")
        {
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Login> Logins { get; set; }

        public IDbSet<Issue> Issues { get; set; }

        public DbContext DbContext => this;

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
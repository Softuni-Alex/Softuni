using DbEntities.Models;
using System.Data.Entity;

namespace DbEntities
{
    public class IssueTrackerContext : DbContext
    {
        public IssueTrackerContext()
            : base("name=IssueTrackerContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Issue> Issues { get; set; }

        public virtual DbSet<Status> IssueStatuses { get; set; }

        public virtual DbSet<Priority> IssuePriorities { get; set; }

        public virtual DbSet<Role> UserRoles { get; set; }

        public virtual DbSet<Login> Logins { get; set; }
    }
}
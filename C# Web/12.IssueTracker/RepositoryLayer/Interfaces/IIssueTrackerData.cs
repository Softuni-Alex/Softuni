using DbEntities.Models;

namespace RepositoryLayer.Interfaces
{
    public interface IIssueTrackerData
    {
        IRepository<Issue> Issue { get; }

        IRepository<User> User { get; }

        IRepository<Status> Status { get; }

        IRepository<Role> Role { get; }

        IRepository<Priority> Priority { get; }

        IRepository<Login> Logins { get; }

        int SaveChanges();

        int ExecuteSqlCommand(string command);
    }
}

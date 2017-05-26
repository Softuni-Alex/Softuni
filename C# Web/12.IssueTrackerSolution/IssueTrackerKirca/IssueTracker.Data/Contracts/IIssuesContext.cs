namespace IssueTracker.Data.Contracts
{
    using System.Data.Entity;
    using Models;

    public interface IIssuesContext
    {
        IDbSet<User> Users { get; }
        IDbSet<Login> Logins { get; }
        IDbSet<Issue> Issues { get; }
        DbContext DbContext { get; }
        int SaveChanges();
        IDbSet<T> Set<T>()
           where T : class;
    }
}

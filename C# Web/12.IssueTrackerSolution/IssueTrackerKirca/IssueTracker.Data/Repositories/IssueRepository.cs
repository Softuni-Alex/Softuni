namespace IssueTracker.Data.Repositories
{
    using Contracts;
    using Models;
    public class IssueRepository : BaseRepository<Issue>
    {
        public IssueRepository(IIssuesContext dbContext)
            : base(dbContext)
        {
        }
    }
}

namespace IssueTracker.Data.Repositories
{
    using Contracts;
    using Models;

    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(IIssuesContext dbContext) 
            : base(dbContext)
        {
        }


    }
}

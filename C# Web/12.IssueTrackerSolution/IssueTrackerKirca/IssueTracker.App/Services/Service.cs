namespace IssueTracker.App.Services
{
    using Data;
    using Data.Contracts;
    using Data.Repositories;

    public abstract class Service
    {
        private readonly IIssuesContext context;

        protected Service()
            : this(new IssuesContext())
        {

        }

        protected Service(IIssuesContext context)
        {
            this.context = context;
        }

        protected UserRepository UserRepository => new UserRepository(this.context);

        protected LoginRepository LoginRepository => new LoginRepository(this.context);

        protected IssueRepository IssueRepository => new IssueRepository(this.context);

        protected IIssuesContext Context => this.context;

        protected int SaveChanges() => this.context.SaveChanges();

    }
}

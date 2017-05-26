namespace IssueTracker.Data.Repositories
{
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    using Contracts;
    using Models;

    public class LoginRepository : BaseRepository<Login>
    {
        public LoginRepository(IIssuesContext dbContext) 
            : base(dbContext)
        {
        }

        public User RetrieveCurrentlyLogged()
        {
            Login lastLogin = this.entityTable.FirstOrDefault(l => l.IsActive);

            return lastLogin?.User;
        }
    }
}

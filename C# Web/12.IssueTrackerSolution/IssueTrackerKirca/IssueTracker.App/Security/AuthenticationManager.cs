namespace IssueTracker.App.Security
{
    using System.Linq;
    using Data.Contracts;
    using Models;
    using Models.Enums;
    using SimpleHttpServer.Models;
    using Utillities;

    public class AuthenticationManager
    {
        private IIssuesContext context;

        public AuthenticationManager(IIssuesContext context)
        {
            this.context = context;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            Login login =  this.context.Logins
                .FirstOrDefault(l => l.IsActive && l.SessionId == session.Id);

            if (login == null)
            {
                return false;
            }

            if (!ViewBag.Bag.ContainsKey("username"))
            {
                ViewBag.Bag.Add("username", login.User.Username);
            }
            else
            {
                ViewBag.Bag["username"] = login.User.Username;
            }

            return true;
        }

        public bool IsCurrentUserPost(int id, HttpSession session)
        {
            Issue issue = this.context.Issues.Find(id);

            return issue.Author.Id == this.context.Logins
                       .First(l => l.IsActive && l.SessionId == session.Id).User.Id;
        }
    }
}

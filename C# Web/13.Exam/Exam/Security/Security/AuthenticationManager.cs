using RepositoryLayer.Interfaces;
using SimpleHttpServer.Models;
using System.Linq;

namespace Security.Security
{
    public class AuthenticationManager
    {
        private readonly ISoftuniStoreData context;

        public AuthenticationManager(ISoftuniStoreData context)
        {
            this.context = context;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            var login = this.context.Logins.Query()
                .FirstOrDefault(l => l.IsActive && l.SessionId == session.Id);

            if (login == null)
            {
                return false;
            }

            return true;
        }

        public bool IsAdmin(HttpSession session)
        {
            var login = this.context.Logins.Query().FirstOrDefault(l => l.IsActive && l.SessionId == session.Id);

            if (login != null)
            {
                var userId = login.UserId;

                var isAdmin = this.context.User.Query().Any(u => u.Id == userId && u.IsAdministrator);

                if (isAdmin)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        //        public bool IsCurrentUserPost(int id, HttpSession session)
        //        {
        //            Issue issue = this.context.Issues.Find(id);
        //
        //            return issue.Author.Id == this.context.Logins
        //                       .First(l => l.IsActive && l.SessionId == session.Id).User.Id;
        //        }
    }
}

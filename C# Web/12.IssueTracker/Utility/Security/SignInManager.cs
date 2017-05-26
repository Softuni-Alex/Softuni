using RepositoryLayer.Interfaces;
using SimpleHttpServer.Models;
using System.Linq;

namespace Utility.Security
{
    public class SignInManager
    {
        private IIssueTrackerData data;

        public SignInManager(IIssueTrackerData data)
        {
            this.data = data;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            return this.data.Logins.Query().Any(l => l.IsActive && l.SessionId == session.Id);
        }
    }
}

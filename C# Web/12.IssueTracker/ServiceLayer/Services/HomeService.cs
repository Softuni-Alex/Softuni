using DbEntities.Models;
using RepositoryLayer.Interfaces;
using ServiceLayer.Interfaces;
using SimpleHttpServer.Models;
using System.Linq;

namespace ServiceLayer.Services
{
    public class HomeService : BaseService, IHomeService
    {
        public HomeService(IIssueTrackerData data)
            : base(data)
        {
        }

        public User FindUserBySession(HttpSession session)
        {
            var firstOrDefault = this.Data.Logins.Query().FirstOrDefault(l => l.SessionId == session.Id);

            if (firstOrDefault != null)
            {
                var user = new User()
                {
                    Id = firstOrDefault.UserId
                };

                return user;
            }

            return null;
        }

        public string GetUserNameByUserId(int userId)
        {
            return this.Data.User.Query().FirstOrDefault(u => u.Id == userId).Username;
        }
    }
}

using SharpStore.Models;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;
using System.Linq;

namespace SharpStore.Utilities
{
    class AuthenticationManager
    {
        public static User GetAuthenticatedUser(string sessionId)
        {
            var firstOrDefault = Data.Data.Context.Logins.FirstOrDefault(login =>
                login.SessionId == sessionId
                && login.isActive);
            if (firstOrDefault != null)
                return firstOrDefault.User;
            return null;
        }

        public static void Logout(HttpResponse response, string sessionId)
        {
            var firstOrDefault = Data.Data.Context.Logins.FirstOrDefault(login =>
           login.SessionId == sessionId
           && login.isActive);
            firstOrDefault.isActive = false;
            Data.Data.Context.SaveChanges();
            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }

    }
}

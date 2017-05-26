using System;
using System.Linq;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;
using SimpleMVC.App.Data;
using SimpleMVC.App.Models;

namespace SimpleMVC.App.Security
{
    public class SignInManager
    {
        private PizzaMoreContext dbContext;

        public SignInManager(PizzaMoreContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            bool isAuthenticated = this.dbContext.Sessions.Any(s => s.SessionId == session.Id && s.IsActive);

            return isAuthenticated;
        }

        public void Logout(HttpResponse response, string sessionId)
        {
            Session sessionEntity = this.dbContext.Sessions.FirstOrDefault(s => s.SessionId == sessionId);
            sessionEntity.IsActive = false;  
            this.dbContext.SaveChanges();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}

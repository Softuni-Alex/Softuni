using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpStore.BindingModels;
using SharpStore.Data;
using SharpStore.Models;

namespace SharpStore.Services
{
    public class LoginService : Service
    {
        public LoginService(SharpStoreContext context)
            : base(context)
        {
        }

        public User GetCorrespondingUser(LoginUserBindingModel lubm)
        {
            var user = Data.Data.Context.Users.FirstOrDefault(
                  user1 => user1.Username == lubm.Username
                  && user1.Password == lubm.Password);

            return user;
        }

        public void LoginUser(User user, string sessionId)
        {
            Login login = new Login()
            {
              User = user,
              SessionId = sessionId,
              isActive = true
            };

            this.context.Logins.Add(login);
            this.context.SaveChanges();
        }
    }
}

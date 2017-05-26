using DataTransferObjects.BindingModels;
using RepositoryLayer.Interfaces;
using ServiceLayer.Interfaces;
using SimpleHttpServer.Models;
using Utility.Interfaces;

namespace ServiceLayer.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IAccountManager manager;

        public UserService(IIssueTrackerData data, IAccountManager manager)
            : base(data)
        {
            this.manager = manager;
        }

        public void Register(RegisterUserBindingModel registerModel)
        {
            base.CheckIfNull(registerModel);

            this.manager.CheckIfRegisterModelIsValid(registerModel);
        }

        public void Login(LoginUserBingingModel loginModel, string sessionId)
        {
            base.CheckIfNull(loginModel);

            this.manager.LogUser(loginModel, sessionId);
        }

        public void Logout(HttpResponse response, string sessionId)
        {
            this.manager.Logout(response, sessionId);
        }
    }
}

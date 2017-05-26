using DataTransferObjects.BindingModels;
using RepositoryLayer.Interfaces;
using ServiceLayer.Interfaces;
using SimpleHttpServer.Models;

namespace ServiceLayer.Services
{
    public class AccountService : Service, IAccountService
    {
        private readonly IAccountManagerService manager;

        public AccountService(ISoftuniStoreData data)
            : base(data)
        {
            this.manager = new AccountManagerService(data);
        }

        public bool IsRegistered(RegisterBindingModel registerModel)
        {
            this.CheckIfNull(registerModel);

            return this.manager.IsRegisterModelValid(registerModel);
        }

        public void Login(HttpSession session, LoginBindingModel loginModel)
        {
            this.CheckIfNull(loginModel);

            this.manager.IsLoginModelValid(session, loginModel);
        }

        public void Logout(HttpResponse response, string sessionId)
        {
            this.manager.Logout(response, sessionId);
        }
    }
}

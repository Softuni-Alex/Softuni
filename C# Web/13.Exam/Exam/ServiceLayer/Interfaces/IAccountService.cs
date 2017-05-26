using DataTransferObjects.BindingModels;
using SimpleHttpServer.Models;

namespace ServiceLayer.Interfaces
{
    public interface IAccountService
    {
        bool IsRegistered(RegisterBindingModel registerModel);

        void Login(HttpSession session, LoginBindingModel registerModel);

        void Logout(HttpResponse response, string sessionId);
    }
}

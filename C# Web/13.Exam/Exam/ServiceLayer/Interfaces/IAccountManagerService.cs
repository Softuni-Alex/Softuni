using DataTransferObjects.BindingModels;
using SimpleHttpServer.Models;

namespace ServiceLayer.Interfaces
{
    public interface IAccountManagerService
    {
        bool IsRegisterModelValid(RegisterBindingModel registerModel);

        void IsLoginModelValid(HttpSession session, LoginBindingModel loginModel);

        void Logout(HttpResponse response, string sessionId);
    }
}

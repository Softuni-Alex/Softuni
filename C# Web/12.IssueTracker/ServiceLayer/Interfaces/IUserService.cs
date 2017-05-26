using DataTransferObjects.BindingModels;
using SimpleHttpServer.Models;

namespace ServiceLayer.Interfaces
{
    public interface IUserService
    {
        void Register(RegisterUserBindingModel registerModel);

        void Login(LoginUserBingingModel loginModel, string sessionId);

        void Logout(HttpResponse response, string sessionId);
    }
}

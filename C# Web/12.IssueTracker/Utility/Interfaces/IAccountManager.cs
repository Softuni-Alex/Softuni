using DataTransferObjects.BindingModels;
using SimpleHttpServer.Models;

namespace Utility.Interfaces
{
    public interface IAccountManager
    {
        bool CheckIfRegisterModelIsValid(RegisterUserBindingModel model);

        void LogUser(LoginUserBingingModel loginModel, string sessionId);

        void Logout(HttpResponse response, string sessionId);
    }
}

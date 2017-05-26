using DbEntities.Models;
using SimpleHttpServer.Models;

namespace ServiceLayer.Interfaces
{
    public interface IHomeService
    {
        User FindUserBySession(HttpSession session);

        string GetUserNameByUserId(int userId);
    }
}

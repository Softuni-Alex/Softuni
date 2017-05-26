using SimpleHttpServer;
using SimpleMVC;
using SoftuniStore.Utilities;

namespace SoftuniStore
{
    public class AppStart
    {
        public static void Main(string[] args)
        {
            HttpServer server = new HttpServer(4200, RouteTable.Routes);
            MvcEngine.Run(server, "SoftuniStore");
        }
    }
}

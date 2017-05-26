using SimpleHttpServer;
using SimpleMVC;

namespace Shouter
{
    public class AppStart
    {
        public static void Main(string[] args)
        {
            HttpServer server = new HttpServer(4200, RouteTable.Routes);
            MvcEngine.Run(server, "Shouter");
        }
    }
}

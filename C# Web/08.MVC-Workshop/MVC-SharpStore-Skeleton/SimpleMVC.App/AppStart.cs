using SimpleHttpServer;
using SimpleMVC;

namespace SharpStore
{
    class AppStart
    {
        static void Main()
        {                                     
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "SharpStore");
        }
    }
}

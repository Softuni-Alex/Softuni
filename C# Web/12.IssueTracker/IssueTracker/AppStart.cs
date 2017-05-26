using SimpleHttpServer;
using SimpleMVC;

namespace IssueTracker
{
    public class AppStart
    {
        public static void Main(string[] args)
        {
            HttpServer server = new HttpServer(4200, RouteTable.Routes);
            MvcEngine.Run(server, "IssueTracker");
        }
    }
}

using SimpleHttpServer;
using SimpleMVC;

namespace PizzaForum
{
    public class AppStart
    {
        public static void Main(string[] args)
        {
            HttpServer server = new HttpServer(4200, RouteTable.Routes);
            MvcEngine.Run(server, "PizzaForum");
        }
    }
}
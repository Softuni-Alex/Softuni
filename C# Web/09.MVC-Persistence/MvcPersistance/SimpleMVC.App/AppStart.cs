namespace SimpleMVC.App
{             
    using SimpleHttpServer;

    public class AppStart
    {
        public static void Main(string[] args)
        {
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "SimpleMVC.App");
        }
    }
}

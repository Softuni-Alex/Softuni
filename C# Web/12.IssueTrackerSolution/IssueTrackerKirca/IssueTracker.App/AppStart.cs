namespace IssueTracker.App
{
    using System.Collections.Generic;
    using SimpleHttpServer;
    using SimpleMVC;
    using Utillities;

    public class AppStart
    {
        public static void Main(string[] args)
        {
            ViewBag.Bag = new Dictionary<string, dynamic>();
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "IssueTracker.App");
        }
    }
}

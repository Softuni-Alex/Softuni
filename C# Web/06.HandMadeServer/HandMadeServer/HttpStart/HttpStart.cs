using HttpServer.Enums;
using HttpServer.Http;
using HttpServer.Models;
using System.Collections.Generic;

namespace HttpStart
{
    public class HttpStart
    {
        public static void Main()
        {
            var routes = new List<Route>()
            {
                new Route()
                {
                    Name = "Alex",
                    UrlRegex = @"^/hello$",
                    RequestMethod = RequestMethod.GET,
                    Callable = request => new HttpResponse()
                    {
                        ContentUTF8 = "<h3>Hello from HttpServer :P</h3>",
                        StatusCode = StatusCode.OK
                    }
                }
            };

            HttpServer.Http.HttpServer server = new HttpServer.Http.HttpServer(4200, routes);
            server.Listen();
        }
    }
}
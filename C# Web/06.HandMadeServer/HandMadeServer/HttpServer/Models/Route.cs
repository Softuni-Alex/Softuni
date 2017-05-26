using HttpServer.Enums;
using HttpServer.Http;
using System;

namespace HttpServer.Models
{
    public class Route
    {
        public string Name { get; set; }

        public string UrlRegex { get; set; }

        public RequestMethod RequestMethod { get; set; }

        public Func<HttpRequest, HttpResponse> Callable { get; set; }
    }
}
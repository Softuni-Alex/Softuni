using HttpServer.Enums;
using System.IO;

namespace HttpServer.Http
{
    public static class HttpResponseBuilder
    {
        public static HttpResponse InternalServerError()
        {
            string content = File.ReadAllText("../../../HttpServer/Resources/Pages/500.html");

            return new HttpResponse()
            {
                StatusCode = StatusCode.InternalServerError,
                ContentUTF8 = content
            };
        }

        public static HttpResponse NotFound()
        {
            string content = File.ReadAllText("../../../HttpServer/Resources/Pages/404.html");

            return new HttpResponse()
            {
                StatusCode = StatusCode.NotFound,
                ContentUTF8 = content
            };
        }
    }
}
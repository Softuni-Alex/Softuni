using HttpServer.Enums;
using HttpServer.Models;
using System.Text;

namespace HttpServer.Http
{
    public class HttpRequest
    {
        public HttpRequest()
        {
            this.Header = new Header(HeaderTypes.HttpRequest);
        }

        public string Url { get; set; }

        public string Content { get; set; }

        public Header Header { get; set; }

        public RequestMethod Method { get; set; }

        public override string ToString()
        {
            StringBuilder header = new StringBuilder();

            header.AppendLine($"{this.Method} {this.Url} HTTP/1.0");
            header.AppendLine($"{this.Header}");
            header.AppendLine($"{this.Content}");

            return header.ToString();
        }
    }
}
using HttpServer.Enums;
using HttpServer.Models;
using System;
using System.Text;

namespace HttpServer.Http
{
    public class HttpResponse
    {
        public HttpResponse()
        {
            this.Header = new Header(HeaderTypes.HttpResponse);
            this.Content = new byte[] { };
        }

        public StatusCode StatusCode { get; set; }

        public string StatusMessage
        {
            get { return Enum.GetName(typeof(StatusCode), this.StatusCode); }
        }

        public Header Header { get; set; }

        public byte[] Content { get; set; }

        public string ContentUTF8
        {
            set { this.Content = Encoding.UTF8.GetBytes(value); }
        }

        public override string ToString()
        {
            StringBuilder header = new StringBuilder();

            header.AppendLine($"HTTP/1.0 {this.StatusCode} {this.StatusMessage}");
            header.AppendLine($"{this.Header}");

            return header.ToString();
        }
    }
}
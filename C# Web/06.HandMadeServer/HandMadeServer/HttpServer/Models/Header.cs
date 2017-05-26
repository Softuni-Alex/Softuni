using HttpServer.Enums;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.Models
{
    public class Header
    {
        public Header(HeaderTypes type)
        {
            this.Type = type;
            this.ContentType = "text/html";
            this.OtherParameters = new Dictionary<string, string>();
            this.Cookies = new CookieCollection();
        }

        public HeaderTypes Type { get; set; }

        public string ContentType { get; set; }

        public string ContentLength { get; set; }

        public IDictionary<string, string> OtherParameters { get; set; }

        public ICookieCollection Cookies { get; private set; }

        public override string ToString()
        {
            StringBuilder header = new StringBuilder();

            header.AppendLine("Content-type: " + this.ContentType);

            if (this.Cookies.Count > 0)
            {
                if (this.Type == HeaderTypes.HttpRequest)
                {
                    header.AppendLine("Cookie: " + this.Cookies);
                }
                else if (this.Type == HeaderTypes.HttpResponse)
                {
                    foreach (var cookie in this.Cookies)
                    {
                        header.AppendLine("Set-Cookie: " + cookie);
                    }
                }
            }

            if (this.ContentLength != null)
            {
                header.AppendLine("Content-length: " + this.ContentLength);
            }

            foreach (var otherParameter in this.OtherParameters)
            {
                header.AppendLine($"{otherParameter.Key}: {otherParameter.Value}");
            }

            header.AppendLine();
            header.AppendLine();

            return header.ToString();
        }
    }
}
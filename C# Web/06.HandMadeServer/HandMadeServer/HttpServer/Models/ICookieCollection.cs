using System.Collections.Generic;

namespace HttpServer.Models
{
    public interface ICookieCollection : IEnumerable<Cookie>
    {
        int Count { get; }

        void Add(Cookie cookie);

        bool Contains(string cookieName);

        Cookie this[string name] { get; set; }
    }
}
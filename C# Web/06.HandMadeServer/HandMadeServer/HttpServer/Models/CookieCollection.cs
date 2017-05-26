using System.Collections;
using System.Collections.Generic;

namespace HttpServer.Models
{
    public class CookieCollection : ICookieCollection
    {
        public CookieCollection()
        {
            this.Cookies = new Dictionary<string, Cookie>();
        }

        public IDictionary<string, Cookie> Cookies { get; private set; }

        public int Count
        {
            get { return this.Cookies.Count; }
        }

        public void Add(Cookie cookie)
        {
            this.Cookies.Add(cookie.Name, cookie);
        }

        public bool Contains(string cookieName)
        {
            return this.Cookies.ContainsKey(cookieName);
        }

        public Cookie this[string name]
        {
            get { return this.Cookies[name]; }
            set
            {
                if (this.Cookies.ContainsKey(name))
                {
                    this.Cookies[name] = value;
                }
                this.Cookies.Add(name, value);
            }
        }

        public IEnumerator<Cookie> GetEnumerator()
        {
            return this.Cookies.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join("; ", this.Cookies.Values);
        }
    }
}
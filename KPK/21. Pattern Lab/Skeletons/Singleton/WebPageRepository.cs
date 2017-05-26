namespace WebScraper
{
    using System.Collections.Generic;

    public class WebPageRepository
    {
        private static WebPageRepository webPageRepository;
        private Queue<string> addresses;
        private static object lockedKey = 0;

        public WebPageRepository()
        {
            this.addresses = new Queue<string>();
            this.Seed();
        }

        public bool IsEmpty
        {
            get
            {
                return this.addresses.Count == 0;
            }
        }

        public static WebPageRepository InstancePageRepository
        {
            get
            {
                if (webPageRepository == null)
                {
                    lock (lockedKey)
                    {
                        if (webPageRepository == null)
                        {
                            return new WebPageRepository();
                        }
                    }
                }
                return webPageRepository;
            }
        }

        public void Add(string address)
        {
            this.addresses.Enqueue(address);
        }

        public string Remove()
        {
            return this.addresses.Dequeue();
        }

        private void Seed()
        {
            this.addresses.Enqueue("https://softuni.bg/");
            this.addresses.Enqueue("http://stackoverflow.com/");
            this.addresses.Enqueue("https://www.youtube.com/");
            this.addresses.Enqueue("https://www.google.bg/");
        }
    }
}
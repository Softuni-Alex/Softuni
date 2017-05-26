using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTML_Dispatcher
{
    class Dispatcher
    {
        static void Main(string[] args)
        {
            ElementBuilder div = new ElementBuilder("div");
            div.AddAttribute("id", "page");
            div.AddAttribute("class", "big");
            div.AddContent("<p>Hello</p>");

            Console.WriteLine(div);
            Console.WriteLine();
            Console.WriteLine(div * 2);
            Console.WriteLine();

            Console.WriteLine(HTMLDispatcher.CreateImage("www.pesho.com/party.jpg", "pesho's image", "this is Pesho"));
            Console.WriteLine();

            string url = HTMLDispatcher.CreateURL("www.pesho.com", "Pesho's website", "This is Pesho's Blog");
            Console.WriteLine(url);
            Console.WriteLine();

            Console.WriteLine(HTMLDispatcher.CreateInput("text", "CustComment", "Enter your comment here"));
            Console.WriteLine();
        }
    }
}

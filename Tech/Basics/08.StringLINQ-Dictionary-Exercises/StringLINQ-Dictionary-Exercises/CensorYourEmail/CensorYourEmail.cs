using System;

namespace CensorYourEmail
{
    class CensorYourEmail
    {
        static void Main(string[] args)
        {
            string[] email = Console.ReadLine().Split('@');
            string text = Console.ReadLine();

            string username = email[0];
            string domain = "@" + email[1];

            string whole = username + domain;

            int userLen = username.Length;
            string ne = new string('*', userLen);

            string replacement = ne + domain;

            text = text.Replace(whole, replacement);

            Console.WriteLine(text);
        }
    }
}
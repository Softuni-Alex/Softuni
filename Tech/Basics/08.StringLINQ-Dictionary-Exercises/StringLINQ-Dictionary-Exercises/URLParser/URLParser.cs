using System;

namespace URLParser
{
    class URLParser
    {
        static void Main(string[] args)
        {
            string url = Console.ReadLine();

            //getting protocol
            int protocolIndex = url.IndexOf("://");
            string protocol = string.Empty;

            if (protocolIndex > 0)
            {
                protocol = url.Substring(0, protocolIndex);
            }

            //getting server
            int serverIndex = url.IndexOf("/", protocolIndex + 3);
            string server = string.Empty;
            string resource = "";
            if (serverIndex > 0)
            {
                //getting resource
                resource = url.Substring(serverIndex + 1);
                server = url.Substring(protocolIndex + 3, serverIndex - protocolIndex - 3);
            }
            else if (protocolIndex > 0)
            {
                server = url.Substring(protocolIndex + 3);
            }
            else
            {
                server = url.Substring(protocolIndex + 1);
            }

            Console.WriteLine("[protocol] = \"{0}\"", protocol);
            Console.WriteLine("[server] = \"{0}\"", server);
            Console.WriteLine("[resource] = \"{0}\"", resource);
        }
    }
}
using System;
using System.Collections.Generic;

namespace Phonebook
{
    class Phonebook
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            while (line != "END")
            {
                string[] tokens = line.Split();
                string temp = tokens[0];
                string name = tokens[1];
                string phone = string.Empty;

                if (temp == "A")
                {
                    phone = tokens[2];
                }

                switch (temp)
                {
                    case "A":
                        if (!phonebook.ContainsKey(name))
                        {
                            phonebook.Add(name, phone);
                        }
                        else
                        {
                            phonebook[name] = phone;
                        }
                        break;

                    case "S":
                        if (phonebook.ContainsKey(name))
                        {
                            Console.WriteLine("{0} -> {1}", name, phonebook[name]);
                        }
                        else
                        {
                            Console.WriteLine("Contact {0} does not exist.", name);
                        }
                        break;
                }
                line = Console.ReadLine();
            }
        }
    }
}
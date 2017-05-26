using System;
using System.Collections.Generic;

namespace PhoneBook
{
    class PhoneBook
    {
        static void Main()
        {
            // database
            Dictionary<string, List<string>> phonebook = new Dictionary<string, List<string>>();

            while (true)
            {
                // accept contacts input, before the command "search" appears
                string input = Console.ReadLine();
                string[] contact;
                if (input != "search")
                {
                    // read contact info
                    contact = input.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    string name = contact[0];
                    string phone = contact[1];

                    // in case of new contact
                    if (!phonebook.ContainsKey(name))
                    {
                        List<string> phoneNumbers = new List<string>();
                        phoneNumbers.Add(phone);

                        phonebook.Add(name, phoneNumbers);
                    }
                    else
                    {
                        // in case of new phone number for existing contact
                        if (!phonebook[name].Contains(phone))
                        {
                            phonebook[name].Add(phone);
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            // searching the database
            while (true)
            {
                string contactName = Console.ReadLine();

                if (phonebook.ContainsKey(contactName))
                {
                    Console.WriteLine("{0} -> {1}", contactName, string.Join(", ", phonebook[contactName]));
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exist.", contactName);
                }
            }
        }
    }
}

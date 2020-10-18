using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    class Client
    {
        List<Contact> ContactList;

        public Client()
        {
            Name = "unknown client";
        }

        // Constructor that takes one argument:
        public Client(string name, List<Contact> contactList)
        {
            Name = name;
            ContactList = contactList;
        }

        // Auto-implemented readonly property:
        public string Name { get; }

        public List<Contact> getContactList
        {
            get
            { return ContactList; }
            
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

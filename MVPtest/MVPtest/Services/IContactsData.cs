using MVPtest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPtest.Services
{
    interface IContactsData
    {
        List<Contact> Contacts { get; set; }
        void AddContact(Contact contact);
        void DeleteContact(int id);
        void Save();
        void Load();
    }
}

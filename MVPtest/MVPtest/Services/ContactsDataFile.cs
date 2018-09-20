using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using MVPtest.Model;

namespace MVPtest.Services
{
    class ContactsDataFile : IContactsData
    {
        public List<Contact> Contacts { get; set; }

        public ContactsDataFile()
        {
            Contacts = new List<Contact>();
        }

        public void AddContact(Contact contact)
        {
            if (string.IsNullOrWhiteSpace(contact.Name))
                throw new Exception("Name is empty!");
            else if(string.IsNullOrWhiteSpace(contact.Surname))
                throw new Exception("Name is empty!");
            else if (string.IsNullOrWhiteSpace(contact.Phone))
                throw new Exception("Name is empty!");
            Contacts.Add(contact);
        }

        public void DeleteContact(int id)
        {
            if (id >= 0 && id < Contacts.Count)
                Contacts.RemoveAt(id);
            else
                throw new Exception("Bad index!");
        }

        public void Load()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream("contacts.bin", FileMode.Open))
            {
               Contacts = bf.Deserialize(fs) as List<Contact>;
            }
        }

        public void Save()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs=new FileStream("contacts.bin",FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, Contacts);
            }
        }
    }
}

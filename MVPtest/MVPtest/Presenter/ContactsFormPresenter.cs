using MVPtest.Model;
using MVPtest.Services;
using MVPtest.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPtest.Presenter
{
    class ContactsFormPresenter
    {
        private IContactsForm view;
        private IContactsData data;

        public ContactsFormPresenter(ContactsForm form)
        {
            view = form;
            data = new ContactsDataFile();
        }

        public IEnumerable<Contact> GetContacts()
        {
            return data.Contacts;
        }

        public void AddContact(Contact contact)
        {
            try
            {
                data.AddContact(contact);
                view.UpdateList();
            }
            catch (Exception)
            {
                throw;
            }

            //if (!string.IsNullOrWhiteSpace(contact.Name) &&
            //    !string.IsNullOrWhiteSpace(contact.Surname) &&
            //    !string.IsNullOrWhiteSpace(contact.Phone))
            //{
            //    Contacts.Add(contact);
            //    view.UpdateList();
            //}
            //else
            //{
            //    throw new Exception("Name,surname or phone is empty");
            //}
        }

        public void DeleteContact(int index)
        {
            try
            {
                data.DeleteContact(index);
                view.UpdateList();
            }
            catch (Exception)
            {
                throw;
            }

            //Contacts.RemoveAt(index);

            //view.UpdateList();
        }

        public void Save()
        {
            data.Save();
        }

        public void Load()
        {
            data.Load();
            view.UpdateList();
        }
    }
}

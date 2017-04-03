using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactInformation.Interface;
using ContactInformation.Models;

namespace ContactInformation.Repositories
{
    public class ContactRepository : IContactRepository
    {

        ContactDBEntities ContactDB = new ContactDBEntities();

        public IEnumerable<Contact> GetAll()
        {

            return ContactDB.Contacts;
        }

        public Contact Add(Contact item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            ContactDB.Contacts.Add(item);
            ContactDB.SaveChanges();
            return item;
        }

        public bool Update(Contact item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            var contact = ContactDB.Contacts.Single(a => a.Id == item.Id);
            contact.FirstName = item.FirstName;
            contact.LastName = item.LastName;
            contact.Email = item.Email;
            contact.Phone = item.Phone;
            ContactDB.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            Contact contact = ContactDB.Contacts.Find(id);
            ContactDB.Contacts.Remove(contact);
            ContactDB.SaveChanges();
            return true;
        }
    }
}
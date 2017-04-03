using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactInformation.Repositories;
using ContactInformation.Interface;
using ContactInformation.Models;

namespace ContactInformation.Controllers
{
    public class ContactController : ApiController
    {
        static readonly IContactRepository repository = new ContactRepository();

        public IEnumerable<Contact> GetAllContacts()
        {
            return repository.GetAll();
        }

        public Contact PostContact(Contact item)
        {
            return repository.Add(item);
        }

        public IEnumerable<Contact> PutContact(int id, Contact contact)
        {
            contact.Id = id;
            if (repository.Update(contact))
            {
                return repository.GetAll();
            }
            else
            {
                return null;
            }
        }

        public bool DeleteContact(int id)
        {
            if (repository.Delete(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}

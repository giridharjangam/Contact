using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactInformation.Models;

namespace ContactInformation.Interface
{
    interface IContactRepository
    {
        IEnumerable<Contact> GetAll();
        Contact Add(Contact item);
        bool Update(Contact item);
        bool Delete(int id);

    }
}

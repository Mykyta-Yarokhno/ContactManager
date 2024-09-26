using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManager.Domain.Entities.Contacts;

namespace ContactManager.Domain
{
    public interface IContactRepository
    {
        Task<Contact> GetContactByIdAsync(int id);
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task AddContactAsync(Contact contact);
        Task AddContactAsync(IEnumerable<Contact> contacts);
        Task<Contact> UpdateContactAsync (Contact contact);
        Task DeleteContactAsync(int id);
    }
}

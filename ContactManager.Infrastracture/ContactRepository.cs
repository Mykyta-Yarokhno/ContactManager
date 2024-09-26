using ContactManager.Domain;
using ContactManager.Domain.Entities.Contacts;
using ContactManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Infrastructure
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task AddContactAsync(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task AddContactAsync(IEnumerable<Contact> contact)
        {
            await _context.Contacts.AddRangeAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task<Contact> UpdateContactAsync(Contact contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();

            return contact;
        }

        public async Task DeleteContactAsync(int id)
        {
            var contact = await GetContactByIdAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }
    }
}

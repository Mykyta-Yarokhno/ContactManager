using ContactManager.Domain;
using ContactManager.Domain.Entities.Contacts;

namespace ContactManager.Apllication
{
    public class ContactService
    {
        private readonly IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _repository.GetAllContactsAsync();
        }

        public async Task RegisterContact(IEnumerable<Contact> persons)
        {
            await _repository.AddContactAsync(persons);
        }

        public async Task RegisterContact(Contact person)
        {
            await _repository.AddContactAsync(person);
        }

        public async Task<Contact> UpdateContact(Contact person)
        {
            var contact = await _repository.GetContactByIdAsync(person.Id);

            if (contact == null)
                throw new Exception("Contact not found");

            contact.Update(person);

            return await _repository.UpdateContactAsync(contact);

        }

        public async Task DeleteContact(int id)
        {

            await _repository.DeleteContactAsync(id);
        }
    }
}

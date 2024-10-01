using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using ContactManager.Apllication;
using ContactManager.Domain.Entities.Contacts;
using ContactManager.Api.DTO.Contacts;
using ContactManager.Apllication.Utils;

namespace ContactManagerWebApplication.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactService _contactService;
        private readonly IEntityDataProvider _entityDataProvider;
        public ContactController(ContactService contactService, IEntityDataProvider entityDataProvider)
        {
            _contactService = contactService;
            _entityDataProvider = entityDataProvider;
        }

        public  IActionResult Index()
        {
            var contacts = _contactService.GetContacts();

            return View(contacts.Result);
        }

        [HttpPost]
        public async Task<IActionResult> UploadNewFile(IFormFile file, string fileFormat = nameof(IEntityDataProvider.EntityFormatProviders.CSV))
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is empty");

            var contacts = new List<Contact>();

            var reader = _entityDataProvider.GetDataProvider<Contact>((IEntityDataProvider.EntityFormatProviders)Enum.Parse(typeof(IEntityDataProvider.EntityFormatProviders) , fileFormat) , file.OpenReadStream());

            await _contactService.RegisterContact(reader.Read());
                    
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact([FromBody] ContactDto contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _contactService.UpdateContact(new Contact(contact.Id, contact.Name, contact.DateOfBirth, contact.Married, contact.Phone, contact.Salary));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteContact(int id)
        {

            await _contactService.DeleteContact(id);

            return Ok();
        }
    }
}

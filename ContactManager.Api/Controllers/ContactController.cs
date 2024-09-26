using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using ContactManager.Apllication;
using ContactManager.Domain.Entities.Contacts;
using ContactManager.Api.DTO.Contacts;

namespace ContactManagerWebApplication.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactService _contactService;

        public ContactController(ContactService contactService)
        {
            _contactService = contactService;
        }

        public  IActionResult Index()
        {
            var contacts = _contactService.GetContacts();

            return View(contacts.Result);
        }

        [HttpPost]
        public async Task<IActionResult> UploadNewCsvFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is empty");

            var contacts = new List<Contact>();

            using (var streamReader = new StreamReader(file.OpenReadStream()))
            {
                var cultureInfo = new CultureInfo("en-US");

                // Skip CSV header 
                streamReader.ReadLine();

                string? line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    var values = line.Split(',');

                    if (values.Length == 5)
                    {
                        try
                        {
                            var contact = new Contact
                            (
                                0,
                                values[0],
                                DateTime.Parse(values[1]),
                                bool.Parse(values[2]),
                                values[3],
                                decimal.Parse(values[4], cultureInfo)
                            );

                            contacts.Add(contact);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                }
            }

            if (contacts.Count > 0)
                await _contactService.RegisterContact(contacts);
                    
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

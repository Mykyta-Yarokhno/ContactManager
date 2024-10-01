using System.ComponentModel.DataAnnotations;

namespace ContactManager.Domain.Entities.Contacts
{
    public class Contact:BaseEntity<int>
    {

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; private set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date in the format YYYY-MM-DD")]
        public DateTime DateOfBirth { get; private set; }

        [Required]
        public bool Married { get; private set; }

        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; private set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number")]
        public decimal Salary { get; private set; }

        public Contact()
        {

        }

        public Contact(int id, string name, DateTime dateOfBirth, bool married, string phone, decimal salary)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Married = married;
            Phone = phone;
            Salary = salary;
        }

        public void Update(Contact contact)
        {
            Name = contact.Name;
            DateOfBirth = contact.DateOfBirth;
            Married = contact.Married;
            Phone = contact.Phone;
            Salary = contact.Salary;
        }

    }
}

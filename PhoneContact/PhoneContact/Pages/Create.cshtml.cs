using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhoneContact.DataAccess;
using PhoneContact.Models;

namespace PhoneContact.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ContactContext _dbContext;
        public static List<Contact> Contacts { get; set; } = new List<Contact>();

        [BindProperty]
        public Contact Contact { get; set; } = new Contact
        {
            EmailAddresses = new List<Email> { new Email { EmailAddress = string.Empty } },
            PhoneNumbers = new List<Phone> { new Phone { PhoneNumber = string.Empty, Type = "Mobile" } }
        };

        public CreateModel (ContactContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult OnPost()
        {
            Contact.EmailAddresses = Contact.EmailAddresses
                .Where(e => !string.IsNullOrWhiteSpace(e.EmailAddress))
                .ToList();

            Contact.PhoneNumbers = Contact.PhoneNumbers
                .Where(p => !string.IsNullOrWhiteSpace(p.PhoneNumber))
                .ToList();

            if (!Contact.PhoneNumbers.Any())
            {
                ModelState.AddModelError("Contact.PhoneNumbers", "At least one valid phone number is required.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Contact.Id = Contacts.Count + 1;
            //Contacts.Add(Contact);
            _dbContext.Contacts.Add(Contact);
            _dbContext.SaveChanges();

            TempData["SuccessMessage"] = "Contact added successfully!";
            return RedirectToPage("Index");
        }
    }
}

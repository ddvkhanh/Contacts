using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhoneContact.Models;

namespace PhoneContact.Pages
{
    public class CreateModel : PageModel
    {
        public static List<Contact> Contacts { get; set; } = new List<Contact>();

        [BindProperty]
        public Contact Contact { get; set; } = new Contact
        {
            EmailAddresses = new List<Email> { new Email { EmailAddress = string.Empty } },
            PhoneNumbers = new List<Phone> { new Phone { PhoneNumber = string.Empty, Type = "Mobile" } }
        };

        public IActionResult OnPost()
        {
            EnsureInitialized();

            // Filter out empty email and phone entries
            Contact.EmailAddresses = Contact.EmailAddresses
                .Where(e => !string.IsNullOrWhiteSpace(e.EmailAddress))
                .ToList();

            Contact.PhoneNumbers = Contact.PhoneNumbers
                .Where(p => !string.IsNullOrWhiteSpace(p.PhoneNumber))
                .ToList();

            // Validate at least one phone number
            if (!Contact.PhoneNumbers.Any())
            {
                ModelState.AddModelError("Contact.PhoneNumbers", "At least one valid phone number is required.");
            }

            // Validate the form
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Assign a new ID and save the contact
            Contact.Id = Contacts.Count + 1;
            Contacts.Add(Contact);

            // Success message
            TempData["SuccessMessage"] = "Contact added successfully!";
            return RedirectToPage("Index");
        }

        private void EnsureInitialized()
        {
            Contact ??= new Contact
            {
                EmailAddresses = new List<Email> { new Email { EmailAddress = string.Empty } },
                PhoneNumbers = new List<Phone> { new Phone { PhoneNumber = string.Empty, Type = "Mobile" } }
            };

            Contact.EmailAddresses ??= new List<Email>();
            Contact.PhoneNumbers ??= new List<Phone>();
        }
    }
}

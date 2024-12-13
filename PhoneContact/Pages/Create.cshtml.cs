using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhoneContact.Models;

namespace PhoneContact.Pages
{
    public class CreateModel : PageModel
    {
        public static List<Contact> Contacts { get; set; } = new List<Contact>();

        [BindProperty]
        public Contact Contact { get; set; }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Contact.Id = Contacts.Count + 1;
            Contacts.Add(Contact);

            TempData["SuccessMessage"] = "Contact added successfully";
            return RedirectToPage("Index");
        }
    }
}

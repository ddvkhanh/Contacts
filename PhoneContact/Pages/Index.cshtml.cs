using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhoneContact.Models;

namespace PhoneContact.Pages
{
    public class IndexModel : PageModel
    {
        public List<Contact> Contacts => CreateModel.Contacts;

        public void OnGet()
        {
            if (CreateModel.Contacts == null)
            {
                CreateModel.Contacts = new List<Contact>();
            }
        }
    }
}

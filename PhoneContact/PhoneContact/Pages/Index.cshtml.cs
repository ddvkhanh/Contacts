using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhoneContact.DataAccess;
using PhoneContact.Models;

namespace PhoneContact.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ContactContext _dbContext;
        public List<Contact> Contacts { get; set; }
        public IndexModel(ContactContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            Contacts = _dbContext.Contacts
                .Include(c => c.PhoneNumbers)
                .Include(c => c.EmailAddresses)
                .ToList();

        }
    }
}

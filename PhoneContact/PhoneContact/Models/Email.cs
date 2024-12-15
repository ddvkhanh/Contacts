using System.ComponentModel.DataAnnotations;

namespace PhoneContact.Models
{
    public class Email
    {
        public int Id { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string EmailAddress { get; set; } = string.Empty;
    }
}

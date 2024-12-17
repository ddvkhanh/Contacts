using System.ComponentModel.DataAnnotations;

namespace PhoneContact.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters")]
        public string LastName { get; set; }

        public List<Email> EmailAddresses { get; set; } = new List<Email>();

        [Required(ErrorMessage = "At least one phone number is required")]
        public List<Phone> PhoneNumbers { get; set; } 
    }
}

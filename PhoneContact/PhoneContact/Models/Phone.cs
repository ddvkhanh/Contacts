using System.ComponentModel.DataAnnotations;

namespace PhoneContact.Models
{
    public class Phone
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "Phone type cannot exceed 20 characters")]
        public string Type { get; set; } = "Mobile";
    }
}

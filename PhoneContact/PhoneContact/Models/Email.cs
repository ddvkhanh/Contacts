using System.ComponentModel.DataAnnotations;

namespace PhoneContact.Models
{
    public class Email
    {
        public int Id { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address")]

        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string? EmailAddress { get; set; } = string.Empty;

        [Required]
        public int ContactId { get; set; }
    }
}

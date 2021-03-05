using System.ComponentModel.DataAnnotations;

namespace bART.WebAPI.Models.Contacts
{
    public class CreateContactViewModel
    {
        [Required]
        [EmailAddress]
        [MaxLength(150, ErrorMessage = "EmailAddress could be maximum 150 characters length.")]
        public string Email { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "First name could be minimum 1 character length.")]
        [MaxLength(50, ErrorMessage = "First name could be maximum 50 characters length.")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Last name could be minimum 1 character length.")]
        [MaxLength(100, ErrorMessage = "Last name could be maximum 100 characters length.")]
        public string LastName { get; set; }
    }
}

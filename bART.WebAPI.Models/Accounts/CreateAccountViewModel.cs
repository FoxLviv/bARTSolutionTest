using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace bART.WebAPI.Models.Accounts
{
    public class CreateAccountViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public List<string> ContactEmails { get; set; }
    }
}

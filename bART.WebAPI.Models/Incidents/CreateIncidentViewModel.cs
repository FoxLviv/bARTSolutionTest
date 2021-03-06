using bART.WebAPI.Models.Contacts;
using System.ComponentModel.DataAnnotations;

namespace bART.WebAPI.Models.Incidents
{
    public class CreateIncidentViewModel
    {
        [Required]
        public string AccountName { get; set; }
        [Required]
        public string ContactFirstName { get; set; }
        [Required]
        public string ContactLastName { get; set; }
        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }
        [Required]
        public string Description { get; set; }
    }
}

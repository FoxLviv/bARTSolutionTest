using bART.Services.Models.Contacts;

namespace bART.Services.Models.Incidents
{
    public class CreateIncidentDTO
    {
        public string AccountName { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactEmail { get; set; }
        public string Description { get; set; }
    }
}

using bART.WebAPI.Models.Accounts;
using System.Collections.Generic;

namespace bART.WebAPI.Models.Incidents
{
    public class IncidentViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<AccountViewModel> Accounts { get; set; }
    }
}

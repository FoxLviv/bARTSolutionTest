using bART.Services.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace bART.Services.Models.Incidents
{
    public class IncidentDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<AccountDTO> Accounts { get; set; }
    }
}

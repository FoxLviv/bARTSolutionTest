using bART.Services.Models.Contacts;
using System.Collections.Generic;

namespace bART.Services.Models.Accounts
{
    public class AccountDTO
    {
        public string Name { get; set; }
        public List<ContactDTO> Contacts { get; set; }
    }
}

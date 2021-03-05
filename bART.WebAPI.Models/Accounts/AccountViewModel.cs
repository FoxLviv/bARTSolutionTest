using bART.WebAPI.Models.Contacts;
using System.Collections.Generic;

namespace bART.WebAPI.Models.Accounts
{
    public class AccountViewModel
    {
        public string Name { get; set; }
        public List<ContactViewModel> Contacts { get; set; }
    }
}

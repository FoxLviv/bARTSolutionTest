using System;
using System.Collections.Generic;
using System.Text;

namespace bART.Services.Models.Accounts
{
    public class CreateAccountDTO
    {
        public string Name { get; set; }

        public List<string> ContactEmails { get; set; }
    }
}

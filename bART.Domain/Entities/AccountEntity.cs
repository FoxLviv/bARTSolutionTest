using System.Collections.Generic;

namespace bART.Domain.Entities
{
    public class AccountEntity
    {
        public string Name { get; set; }
        public List<ContactEntity> Contacts { get; set; }
        public string IncidentName { get; set; }
        public IncidentEntity Incident { get; set; }
    }
}

using System.Collections.Generic;

namespace bART.Domain.Entities
{
    public class IncidentEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<AccountEntity> Accounts { get; set; }

    }
}

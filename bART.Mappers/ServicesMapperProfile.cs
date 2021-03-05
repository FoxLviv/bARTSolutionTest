using AutoMapper;
using bART.Domain.Entities;
using bART.Services.Models.Accounts;
using bART.Services.Models.Contacts;
using bART.Services.Models.Incidents;

namespace bART.Mappers
{
    public class ServicesMapperProfile:Profile
    {
        public ServicesMapperProfile()
        {
            CreateMap<CreateAccountDTO, AccountEntity>();
            CreateMap<AccountEntity, AccountDTO>()
                .ForMember(dto => dto.Contacts, opt => opt
                  .MapFrom(ent => ent.Contacts));

            CreateMap<CreateContactDTO, ContactEntity>();
            CreateMap<ContactEntity, ContactDTO>();

            CreateMap<CreateIncidentDTO, IncidentEntity>();
            CreateMap<IncidentEntity, IncidentDTO>();
        }
    }
}

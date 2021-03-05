using AutoMapper;
using bART.Services.Models.Accounts;
using bART.Services.Models.Contacts;
using bART.Services.Models.Incidents;
using bART.WebAPI.Models.Accounts;
using bART.WebAPI.Models.Contacts;
using bART.WebAPI.Models.Incidents;

namespace bART.Mappers
{
    public class WebAPIMapperProfile:Profile
    {
        public WebAPIMapperProfile()
        {
            CreateMap<CreateAccountViewModel, CreateAccountDTO>();
            CreateMap<AccountDTO, AccountViewModel>();

            CreateMap<CreateContactViewModel, CreateContactDTO>();
            CreateMap<ContactDTO, ContactViewModel>();

            CreateMap<CreateIncidentViewModel, CreateIncidentDTO>();
            CreateMap<IncidentDTO, IncidentViewModel>();
        }
    }
}

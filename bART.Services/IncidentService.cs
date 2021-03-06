using AutoMapper;
using bART.Domain;
using bART.Domain.Entities;
using bART.Services.CustomExceptions;
using bART.Services.Interfaces;
using bART.Services.Models.Incidents;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace bART.Services
{
    public class IncidentService : IIncidentService
    {
        readonly bARTDBContext _bBContext;
        readonly IMapper _mapper;

        public IncidentService(bARTDBContext bBContext, IMapper mapper)
        {
            _bBContext = bBContext;
            _mapper = mapper;
        }

        public async Task<IncidentDTO> CreateIncidentAsync(CreateIncidentDTO createIncidentDTO)
        {
            var accountEntity = await _bBContext.Accounts
                .AsTracking()
                .SingleOrDefaultAsync(acc => acc.Name == createIncidentDTO.AccountName);
            if(accountEntity == null)
            {
                throw new ItemNotFoundException($"Account {createIncidentDTO.AccountName} is not in the system");
            }

            var contactEntity = await _bBContext.Contacts
                .AsTracking()
                .SingleOrDefaultAsync(c => c.Email == createIncidentDTO.ContactEmail);


            if (contactEntity == null)
            {
                contactEntity = new ContactEntity(){
                    Email = createIncidentDTO.ContactEmail,
                    FirstName = createIncidentDTO.ContactFirstName,
                    LastName = createIncidentDTO.ContactLastName,
                    AccountName = createIncidentDTO.AccountName
                };
                
                await _bBContext.AddAsync(contactEntity);
            }
            else
            {
                if (contactEntity.AccountName == null)
                    contactEntity.AccountName = createIncidentDTO.AccountName;
            }

            var incidentEntity = _mapper.Map<IncidentEntity>(createIncidentDTO);
            

            await _bBContext.AddAsync(incidentEntity);

            accountEntity.IncidentName = incidentEntity.Name;
            await _bBContext.SaveChangesAsync();

            incidentEntity = await _bBContext.Incidents
                .AsNoTracking()
                .Include(ent => ent.Accounts)
                .ThenInclude(acc=>acc.Contacts)
                .SingleOrDefaultAsync(inc => inc.Name == incidentEntity.Name);

            var incidentDTO = _mapper.Map<IncidentDTO>(incidentEntity);
            
            return incidentDTO;
        }
    }
}

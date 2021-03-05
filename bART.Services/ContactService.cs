using AutoMapper;
using bART.Domain;
using bART.Domain.Entities;
using bART.Services.Interfaces;
using bART.Services.Models.Contacts;
using System.Threading.Tasks;

namespace bART.Services
{
    public class ContactService : IContactService
    {
        private readonly bARTDBContext _dBContext;
        private readonly IMapper _mapper;

        public ContactService(bARTDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }

        public async Task<ContactDTO> CreateContactAsync(CreateContactDTO createContactDTO)
        {
            var contactEntity = _mapper.Map<ContactEntity>(createContactDTO);

            await _dBContext.Contacts.AddAsync(contactEntity);
            await _dBContext.SaveChangesAsync();

            var contactDTO = _mapper.Map<ContactDTO>(contactEntity);
            return contactDTO;
        }
    }
}

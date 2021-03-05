using AutoMapper;
using bART.Domain;
using bART.Domain.Entities;
using bART.Services.Interfaces;
using bART.Services.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace bART.Services
{
    public class AccountService : IAccountService
    {
        private readonly bARTDBContext _dBContext;
        private readonly IMapper _mapper;

        public AccountService(bARTDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }

        public async Task<AccountDTO> CreateAccountAsync(CreateAccountDTO createAccountDTO)
        {
            var accountEntity = _mapper.Map<AccountEntity>(createAccountDTO);
            foreach(var email in createAccountDTO.ContactEmails)
            {
                var contactEntity = await _dBContext.Contacts.SingleOrDefaultAsync(c => c.Email == email);
                contactEntity.AccountName = accountEntity.Name;
            }
            


            await _dBContext.Accounts.AddAsync(accountEntity);
            await _dBContext.SaveChangesAsync();

            accountEntity = await _dBContext.Accounts
                .AsNoTracking()
                .Include(acc => acc.Contacts)
                .SingleOrDefaultAsync(acc => acc.Name == accountEntity.Name);

            var accountDTO = _mapper.Map<AccountDTO>(accountEntity);
            return accountDTO;
        }
    }
}

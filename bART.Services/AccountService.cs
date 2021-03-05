using AutoMapper;
using bART.Domain;
using bART.Domain.Entities;
using bART.Services.Interfaces;
using bART.Services.Models.Accounts;
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

            await _dBContext.Accounts.AddAsync(accountEntity);
            await _dBContext.SaveChangesAsync();

            var accountDTO = _mapper.Map<AccountDTO>(accountEntity);
            return accountDTO;
        }
    }
}

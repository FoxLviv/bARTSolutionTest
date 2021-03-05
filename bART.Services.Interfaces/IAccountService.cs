using bART.Services.Models.Accounts;
using System;
using System.Threading.Tasks;

namespace bART.Services.Interfaces
{
    public interface IAccountService
    {
        Task<AccountDTO> CreateAccountAsync(CreateAccountDTO accountDTO);
    }
}

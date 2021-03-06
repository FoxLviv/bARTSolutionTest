using AutoMapper;
using bART.Services.Interfaces;
using bART.Services.Models.Accounts;
using bART.WebAPI.Models.Accounts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bART.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly IAccountService _accountService;

        public AccountController(IMapper mapper, IAccountService accountService)
        {
            _mapper = mapper;
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccountAsync(CreateAccountViewModel createAccountViewModel)
        {
            var createAccountDTO = _mapper.Map<CreateAccountDTO>(createAccountViewModel);
            var resultDTO = await _accountService.CreateAccountAsync(createAccountDTO);
            var resultVM = _mapper.Map<AccountViewModel>(resultDTO);
            return Ok(resultVM);
        }
    }
}

using AutoMapper;
using bART.Services.Interfaces;
using bART.Services.Models.Contacts;
using bART.WebAPI.Models.Contacts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bART.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ContactController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly IContactService _contactService;

        public ContactController(IMapper mapper, IContactService contactService)
        {
            _mapper = mapper;
            _contactService = contactService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactAsync(CreateContactViewModel createContactViewModel)
        {
            var createCommentDTO = _mapper.Map<CreateContactDTO>(createContactViewModel);
            var resultDTO = await _contactService.CreateContactAsync(createCommentDTO);
            var resultVM = _mapper.Map<ContactViewModel>(resultDTO);
            return Ok(resultVM);
        }
    }
}

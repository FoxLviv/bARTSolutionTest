using AutoMapper;
using bART.Services.Interfaces;
using bART.Services.Models.Incidents;
using bART.WebAPI.Models.Incidents;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bART.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly IIncidentService _incidentService;

        public IncidentController(IMapper mapper, IIncidentService incidentService)
        {
            _mapper = mapper;
            _incidentService = incidentService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateIncidentAsync(CreateIncidentViewModel createIncidentViewModel)
        {
            var createIncidentDTO = _mapper.Map<CreateIncidentDTO>(createIncidentViewModel);
            var resultDTO = await _incidentService.CreateIncidentAsync(createIncidentDTO);
            var resultVM = _mapper.Map<IncidentViewModel>(resultDTO);
            return Ok(resultVM);
        }
    }
}

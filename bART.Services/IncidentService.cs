using AutoMapper;
using bART.Domain;
using bART.Domain.Entities;
using bART.Services.Interfaces;
using bART.Services.Models.Incidents;
using System.Threading.Tasks;

namespace bART.Services
{
    public class IncidentService : IIncedentService
    {
        readonly bARTDBContext _bBContext;
        readonly IMapper _mapper;

        public IncidentService(bARTDBContext bBContext, IMapper mapper)
        {
            _bBContext = bBContext;
            _mapper = mapper;
        }

        public Task<IncidentDTO> CreateIncidentAsync(CreateIncidentDTO incidentDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}

using bART.Services.Models.Incidents;
using System.Threading.Tasks;

namespace bART.Services.Interfaces
{
    public interface IIncidentService
    {
        Task<IncidentDTO> CreateIncidentAsync(CreateIncidentDTO incidentDTO);
    }
}

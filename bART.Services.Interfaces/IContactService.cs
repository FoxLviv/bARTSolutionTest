using bART.Services.Models.Contacts;
using System.Threading.Tasks;

namespace bART.Services.Interfaces
{
    public interface IContactService
    {
        Task<ContactDTO> CreateContactAsync(CreateContactDTO contactDTO);
    }
}

using Application.Models.Organizer;

namespace Application.Common.Interfaces.Services
{
    public interface IOrganizerService
    {
        Task<IEnumerable<OrganizerDto>> GetAllAsync();
        Task<OrganizerDto> GetByIdAsync(int id);
        Task<OrganizerDto> CreateAsync(OrganizerForCreationDto organizerForCreationDto);
        Task UpdateAsync(OrganizerForUpdateDto organizerForUpdateDto);
        Task DeleteAsync(int id);
    }
}
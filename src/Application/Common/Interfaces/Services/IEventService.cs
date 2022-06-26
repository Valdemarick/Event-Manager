using Application.Models.Event;

namespace Application.Common.Interfaces.Services
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetAllAsync();
        Task<EventDto> GetByIdAsync(int id);
        Task<EventDto> CreateAsync(EventForCreationDto eventForCreationDto);
        Task UpdateAsync(EventForUpdateDto eventForUpdateDto);
        Task DeleteAsync(int id);
    }
}
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Application.Models.Event;
using AutoMapper;
using Domain.Entities;
using Infastructure.Services.Common;

namespace Infastructure.Services
{
    public class EventService : BaseService, IEventService
    {
        private readonly IEventRepository _repository;

        public EventService(IEventRepository repository, IMapper mapper) : base(mapper) => _repository = repository;

        public async Task<IEnumerable<EventDto>> GetAllAsync()
        {
            var events = await _repository.GetAllAsync();
            return Mapper.Map<IEnumerable<EventDto>>(events);
        }

        public async Task<EventDto> GetByIdAsync(int id)
        {
            var @event = await _repository.GetByIdAsync(id);
            return Mapper.Map<EventDto>(@event);
        }

        public async Task<EventDto> CreateAsync(EventForCreationDto eventForCreationDto)
        {
            var entity = Mapper.Map<Event>(eventForCreationDto);
            var created = await _repository.CreateAsync(entity);
            return Mapper.Map<EventDto>(created);
        }

        public async Task UpdateAsync(EventForUpdateDto eventForUpdateDto)
        {
            var entiy = Mapper.Map<Event>(eventForUpdateDto);
            await _repository.UpdateAsync(entiy);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Application.Models.Organizer;
using AutoMapper;
using Domain.Entities;
using Infastructure.Services.Common;

namespace Infastructure.Services
{
    public class OrganizerService : BaseService, IOrganizerService
    {
        private readonly IOrganizerRepository _repository;

        public OrganizerService(IOrganizerRepository repository, IMapper mapper) : base(mapper) => _repository = repository;

        public async Task<IEnumerable<OrganizerDto>> GetAllAsync()
        {
            var organizers = await _repository.GetAllAsync();
            return Mapper.Map<IEnumerable<OrganizerDto>>(organizers);
        }

        public async Task<OrganizerDto> GetByIdAsync(int id)
        {
            var organizer = await _repository.GetByIdAsync(id);
            return Mapper.Map<OrganizerDto>(organizer);
        }

        public async Task<OrganizerDto> CreateAsync(OrganizerForCreationDto organizerForCreationDto)
        {
            var entity = Mapper.Map<Organizer>(organizerForCreationDto);
            var created = await _repository.CreateAsync(entity);
            return Mapper.Map<OrganizerDto>(created);
        }

        public async Task UpdateAsync(OrganizerForUpdateDto organizerForUpdateDto)
        {
            var entity = Mapper.Map<Organizer>(organizerForUpdateDto);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Application.Models.Place;
using AutoMapper;
using Domain.Entities;
using Infastructure.Services.Common;

namespace Infastructure.Services
{
    public class PlaceService : BaseService, IPlaceService
    {
        private readonly IPlaceRepository _repository;

        public PlaceService(IPlaceRepository repository, IMapper mapper) : base(mapper) => _repository = repository;

        public async Task<IEnumerable<PlaceDto>> GetAllAsync()
        {
            var places = await _repository.GetAllAsync();
            return Mapper.Map<IEnumerable<PlaceDto>>(places);
        }

        public async Task<PlaceDto> GetByIdAsync(int id)
        {
            var place = await _repository.GetByIdAsync(id);
            return Mapper.Map<PlaceDto>(place);
        }

        public async Task<PlaceDto> CreateAsync(PlaceForCreationDto place)
        {
            var entity = Mapper.Map<Place>(place);
            var created = await _repository.CreateAsync(entity);
            return Mapper.Map<PlaceDto>(created);
        }

        public async Task UpdateAsync(PlaceForUpdateDto placeForUpdateDto)
        {
            var entity = Mapper.Map<Place>(placeForUpdateDto);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
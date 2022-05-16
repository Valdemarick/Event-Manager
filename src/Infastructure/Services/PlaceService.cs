using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Application.Models.Place;
using AutoMapper;
using Domain.Entities;

namespace Infastructure.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _repository;
        private readonly IMapper _mapper;

        public PlaceService(IPlaceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlaceDto>> GetAllAsync()
        {
            var places = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PlaceDto>>(places);
        }

        public async Task<PlaceDto> GetByIdAsync(int id)
        {
            var place = await _repository.GetByIdAsync(id);
            return _mapper.Map<PlaceDto>(place);
        }

        public async Task<PlaceDto> CreateAsync(PlaceDto place)
        {
            var entity = _mapper.Map<Place>(place);
            var created = await _repository.CreateAsync(entity);
            return _mapper.Map<PlaceDto>(created);
        }

        public async Task UpdateAsync(PlaceForUpdateDto placeForUpdateDto)
        {
            var entity = _mapper.Map<Place>(placeForUpdateDto);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
using Application.Models.Place;

namespace Application.Common.Interfaces.Services
{
    public interface IPlaceService
    {
        Task<IEnumerable<PlaceDto>> GetAllAsync();
        Task<PlaceDto> GetByIdAsync(int id);
        Task<PlaceDto> CreateAsync(PlaceDto placeDto);
        Task UpdateAsync(PlaceForUpdateDto placeForUpdateDto);
        Task DeleteAsync(int id);
    }
}
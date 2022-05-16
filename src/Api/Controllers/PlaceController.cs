using Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/places")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _service;

        public PlaceController(IPlaceService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var places = await _service.GetAllAsync();
            return Ok(places);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var place = await _service.GetByIdAsync(id);
            if (place == null)
            {
                return NotFound();
            }

            return Ok(place);
        }
    }
}
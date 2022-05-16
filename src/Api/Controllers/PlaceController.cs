using Application.Common.Interfaces.Services;
using Application.Models.Place;
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
        [ActionName(nameof(GetByIdAsync))]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var place = await _service.GetByIdAsync(id);
            if (place == null)
            {
                return NotFound();
            }

            return Ok(place);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] PlaceForCreationDto placeDto)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(placeDto);
            }

            var created = await _service.CreateAsync(placeDto);
            return CreatedAtAction(nameof(GetByIdAsync), new {id = created.Id}, created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PlaceForUpdateDto placeDto)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(placeDto);
            }

            await _service.UpdateAsync(placeDto);
            return NoContent();
        }
    }
}
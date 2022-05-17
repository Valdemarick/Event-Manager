using Application.Common.Interfaces.Services;
using Application.Models.Organizer;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/organizers")]
    [ApiController]
    public class OrganizerController : ControllerBase
    {
        private readonly IOrganizerService _service;

        public OrganizerController(IOrganizerService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var organizers = await _service.GetAllAsync();
            return Ok(organizers);
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetByIdAsync))]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var organizer = await _service.GetByIdAsync(id);
            if (organizer == null)
            {
                return NotFound();
            }

            return Ok(organizer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] OrganizerForCreationDto organizerDto)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(organizerDto);
            }

            var created = await _service.CreateAsync(organizerDto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = created.Id }, created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] OrganizerForUpdateDto organizerDto)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(organizerDto);
            }

            await _service.UpdateAsync(organizerDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
using Application.Common.Interfaces.Services;
using Application.Models.Event;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _service;

        public EventController(IEventService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var events = await _service.GetAllAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetByIdAsync))]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var @event = await _service.GetByIdAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EventForCreationDto eventDto)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(eventDto);
            }

            var created = await _service.CreateAsync(eventDto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = created.Id }, created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] EventForUpdateDto eventDto)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(eventDto);
            }

            await _service.UpdateAsync(eventDto);
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
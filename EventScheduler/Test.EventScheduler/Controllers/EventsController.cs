using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Test.EventScheduler.Data.DTOs;
using Test.EventScheduler.Services.Interfaces;

namespace Test.EventScheduler.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _service;

        public EventsController(IEventService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents([FromQuery] bool upcommingOnly)
        {
            return Ok(await _service.GetEvents(upcommingOnly));
        }

        [HttpGet]
        [Route("{eventId}")]
        public async Task<IActionResult> GetEvent(int eventId)
        {
            return Ok(await _service.GetEvent(eventId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventDto eventDto)
        {
            return Ok(await _service.CreateEvent(eventDto));
        }

        [HttpPut]
        [Route("{eventId}")]
        public async Task<IActionResult> UpdateEvent(int eventId, UpdateEventDto  eventDto)
        {
            eventDto.EventId = eventId;

            await _service.UpdateEvent(eventDto);

            return NoContent();
        }

        [HttpDelete]
        [Route("{eventId}")]
        public async Task<IActionResult> DeleteEvent(int eventId)
        {
            await _service.DeleteEvent(eventId);

            return NoContent();
        }
    }
}

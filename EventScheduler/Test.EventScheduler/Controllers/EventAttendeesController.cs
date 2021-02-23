using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.EventScheduler.Services.Interfaces;

namespace Test.EventScheduler.Controllers
{
    [Route("api/events/{eventId}/attendees")]
    [ApiController]
    public class EventAttendeesController : ControllerBase
    {
        private readonly IEventAttendeeService _service;

        [HttpGet]
        public async Task<IActionResult> GetEventAttendees(int eventId)
        {
            return Ok(await _service.GetEventAttendees(eventId));
        }

        [HttpPost]
        public async Task<IActionResult> AddEventAttendee(int eventId, [FromBody] int userId)
        {
            await _service.AddEventAttendee(eventId, userId);

            return NoContent();
        }

        [HttpDelete]
        [Route("{attendeeId}")]
        public async Task<IActionResult> RemoveEventAttendee(int eventId, int attendeeId)
        {
            await _service.RemoveEventAttendee(eventId, attendeeId);

            return NoContent();
        }
    }
}

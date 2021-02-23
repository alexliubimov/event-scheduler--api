using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.EventScheduler.Data.DTOs;

namespace Test.EventScheduler.Services.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetEvents(bool upcomingOnly);
        Task<IEnumerable<EventDto>> GetEventsForOrganizer(int organizerId);
        Task<EventDto> GetEvent(int eventId);
        Task<int> CreateEvent(CreateEventDto createEventDto);
        Task UpdateEvent(UpdateEventDto updateEventDto);
        Task DeleteEvent(int eventId);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.EventScheduler.Data.DTOs;

namespace Test.EventScheduler.Repositories.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<EventDto>> GetEvents(int? page, int? size, DateTime? currentTime = null);
        Task<EventDto> GetEvent(int eventId);
        Task<int> CreateEvent(CreateEventDto createEventDto);
        Task<int> UpdateEvent(UpdateEventDto updateEventDto);
        Task<bool> DeleteEvent(int eventId);
        Task<bool> AddAttendee(int eventId, int userId);
        Task<bool> RemoveAttendee(int eventId, int userId);
    }
}

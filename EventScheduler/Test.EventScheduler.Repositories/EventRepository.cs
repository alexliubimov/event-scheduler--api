using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using Test.EventScheduler.Data.DTOs;
using Test.EventScheduler.DataAccess;
using Test.EventScheduler.Repositories.Interfaces;

namespace Test.EventScheduler.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventSchedulerContext _context;

        public EventRepository(EventSchedulerContext context)
        {
            _context = context;
        }

        public Task<bool> AddAttendee(int eventId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateEvent(CreateEventDto createEventDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEvent(int eventId)
        {
            throw new NotImplementedException();
        }

        public Task<EventDto> GetEvent(int eventId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EventDto>> GetEvents(DateTime? currentTime = null)
        {
            return await _context.Events.;
        }

        public Task<bool> RemoveAttendee(int eventId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateEvent(UpdateEventDto updateEventDto)
        {
            throw new NotImplementedException();
        }
    }
}

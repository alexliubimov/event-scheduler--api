using AutoMapper;
using System;
using System.Collections.Generic;
using Test.EventScheduler.DataAccess.Extensions;
using System.Threading.Tasks;
using Test.EventScheduler.Data.DTOs;
using Test.EventScheduler.DataAccess;
using Test.EventScheduler.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Test.EventScheduler.Services.Exceptions;
using System.Linq;
using Test.EventScheduler.DataAccess.Models;

namespace Test.EventScheduler.Services
{
    public class EventAttendeeService : IEventAttendeeService
    {
        private readonly IDataContext _context;
        private readonly IMapper _mapper;

        public EventAttendeeService(IDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddEventAttendee(int eventId, int userId)
        {
            var eventTask = _context.Events.GetActiveEventById(eventId).FirstOrDefaultAsync();
            var userTask = _context.Users.GetActiveUserById(userId).FirstOrDefaultAsync();

            var eventEntity = await eventTask;
            var userEntity = await userTask;

            if (eventEntity == null || userEntity == null)
            {
                throw new ItemNotFoundException();
            }
            
            if (eventEntity.Attendees.Any(a => a.UserId == userId))
            {
                throw new InvalidActionException();
            }

            eventEntity.Attendees.Add(userEntity);
            _context.Save();
        }

        public async Task<IEnumerable<UserDto>> GetEventAttendees(int eventId)
        {
            var eventEntity = await _context.Events.GetActiveEventById(eventId).FirstOrDefaultAsync();

            if (eventEntity == null)
            {
                throw new ItemNotFoundException();
            }

            return _mapper.Map<IEnumerable<UserDto>>(eventEntity.Attendees);
        }

        public async Task RemoveEventAttendee(int eventId, int userId)
        {
            var eventEntity = await _context.Events.GetActiveEventById(eventId).FirstOrDefaultAsync();

            if (eventEntity == null || eventEntity.Attendees.All(a => a.UserId != userId))
            {
                throw new ItemNotFoundException();
            }

            eventEntity.Attendees.Remove(new User { UserId = userId });
            _context.Save();
        }
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.EventScheduler.Data.DTOs;
using Test.EventScheduler.DataAccess;
using Test.EventScheduler.DataAccess.Extensions;
using Test.EventScheduler.DataAccess.Models;
using Test.EventScheduler.Services.Exceptions;
using Test.EventScheduler.Services.Interfaces;

namespace Test.EventScheduler.Services
{
    public class EventService : IEventService
    {
        private readonly IDataContext _context;
        private readonly IMapper _mapper;

        public EventService(IDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventDto>> GetEvents(bool upcomingOnly)
        {
            IEnumerable<Event> events;

            if (upcomingOnly)
            {
                events = await _context
                    .Events
                    .GetUpcomingEvents()
                    .ToListAsync();
            } 
            else
            {
                events = await _context
                    .Events
                    .GetActiveEventsSorted()
                    .ToListAsync();
            }

            return _mapper.Map<IEnumerable<EventDto>>(events);
        }

        public async Task<IEnumerable<EventDto>> GetEventsForOrganizer(int organizerId)
        {
            var events = await _context
                .Events
                .GetEventsForOrganizer(organizerId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<EventDto>>(events);
        }

        public async Task<int> CreateEvent(CreateEventDto createEventDto)
        {
            var eventEntity = _mapper.Map<Event>(createEventDto);

            _context.Events.Add(eventEntity);
            _context.Save();

            return eventEntity.EventId;
        }

        public async Task UpdateEvent(UpdateEventDto updateEventDto)
        {
            var eventEntity = await _context
                .Events
                .GetActiveEventById(updateEventDto.EventId)
                .FirstOrDefaultAsync();

            if (eventEntity == null)
            {
                throw new ItemNotFoundException();
            }

            eventEntity.OrganizerId = updateEventDto.OrganizerId;
            eventEntity.Title = updateEventDto.Title;
            eventEntity.Description = updateEventDto.Description;
            eventEntity.Location = updateEventDto.Location;
            eventEntity.StartTime = updateEventDto.StartTime;
            eventEntity.EndTime = updateEventDto.EndTime;

            _context.Save();
        }

        public async Task DeleteEvent(int eventId)
        {
            var eventEntity = await _context
                .Events
                .GetActiveEventById(eventId)
                .FirstOrDefaultAsync();

            if (eventEntity == null)
            {
                throw new ItemNotFoundException();
            }

            eventEntity.IsDeleted = true;

            _context.Save();
        }

        public async Task<EventDto> GetEvent(int eventId)
        {
            var eventEntity = await _context
                .Events
                .GetActiveEventById(eventId)
                .FirstOrDefaultAsync();

            if (eventEntity == null)
            {
                throw new ItemNotFoundException();
            }

            return _mapper.Map<EventDto>(eventEntity);
        }        
    }
}

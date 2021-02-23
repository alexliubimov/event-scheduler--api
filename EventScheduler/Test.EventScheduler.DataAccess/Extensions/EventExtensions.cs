using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Test.EventScheduler.DataAccess.Models;

namespace Test.EventScheduler.DataAccess.Extensions
{
    public static class EventExtensions
    {
        public static IQueryable<Event> GetActiveEventById(this IQueryable<Event> events, int eventId)
        {
            return events
                .Include(e => e.EventOrganizer)
                .Include(e => e.Attendees)
                .GetActiveEvents()
                .Where(e => e.EventId == eventId);
        }

        public static IQueryable<Event> GetActiveEvents(this IQueryable<Event> events)
        {
            return events
                .Where(e => !e.IsDeleted);
        }

        public static IQueryable<Event> GetActiveEventsSorted(this IQueryable<Event> events)
        {
            return events
                .Include(e => e.EventOrganizer)
                .Include(e => e.Attendees)
                .GetActiveEvents()
                .OrderBy(e => e.StartTime);
        }

        public static IQueryable<Event> GetUpcomingEvents(this IQueryable<Event> events)
        {
            return events
                .Include(e => e.EventOrganizer)
                .Include(e => e.Attendees)
                .GetActiveEvents()
                .Where(e => e.StartTime > DateTime.Now)
                .OrderBy(e => e.StartTime);
        }          

        public static IQueryable<Event> GetEventsForOrganizer(this IQueryable<Event> events, int organizerId)
        {
            return events
                .Include(e => e.Attendees)
                .Include(e => e.EventOrganizer)
                .Where(e => e.OrganizerId == organizerId)
                .OrderBy(e => e.StartTime);
        }
    }
}

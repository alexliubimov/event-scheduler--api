using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.EventScheduler.Data.DTOs;

namespace Test.EventScheduler.Services.Interfaces
{
    public interface IEventAttendeeService
    {
        Task<IEnumerable<UserDto>> GetEventAttendees(int eventId);
        Task AddEventAttendee(int eventId, int userId);
        Task RemoveEventAttendee(int eventId, int userId);
    }
}

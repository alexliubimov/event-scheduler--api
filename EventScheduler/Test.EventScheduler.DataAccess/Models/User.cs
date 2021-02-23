using System;
using System.Collections.Generic;
using System.Text;

namespace Test.EventScheduler.DataAccess.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }

        public List<Event> AttendedEvents { get; set; }
        public List<Event> OrganizedEvents { get; set; }
    }
}

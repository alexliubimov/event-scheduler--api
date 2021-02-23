using System;
using System.Collections.Generic;
using System.Text;

namespace Test.EventScheduler.DataAccess.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int OrganizerId { get; set; }
        public bool IsDeleted { get; set; }

        public User EventOrganizer { get; set; }
        public List<User> Attendees { get; set; }
    }
}

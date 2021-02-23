using System;
using System.Collections.Generic;
using System.Text;

namespace Test.EventScheduler.Data.DTOs
{
    public class CreateEventDto
    {
        public int OrganizerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

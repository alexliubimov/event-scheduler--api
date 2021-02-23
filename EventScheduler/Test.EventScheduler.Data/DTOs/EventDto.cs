using System;
using System.Collections.Generic;
using System.Text;

namespace Test.EventScheduler.Data.DTOs
{
    public class EventDto : UpdateEventDto
    {
        public string OrganizerName { get; set; }
        public int AttendeesNumber { get; set; }
    }
}

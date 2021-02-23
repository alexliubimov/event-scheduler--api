using System;
using System.Collections.Generic;
using System.Text;

namespace Test.EventScheduler.Data.DTOs
{
    public class UpdateEventDto : CreateEventDto
    {
        public int EventId { get; set; }
    }
}

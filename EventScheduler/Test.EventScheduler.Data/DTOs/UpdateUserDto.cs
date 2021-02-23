using System;
using System.Collections.Generic;
using System.Text;

namespace Test.EventScheduler.Data.DTOs
{
    public class UpdateUserDto : CreateUserDto
    {
        public int UserId { get; set; }
    }
}

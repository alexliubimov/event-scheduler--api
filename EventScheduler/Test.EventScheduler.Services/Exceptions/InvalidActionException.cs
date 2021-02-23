using System;
using System.Collections.Generic;
using System.Text;

namespace Test.EventScheduler.Services.Exceptions
{
    public class InvalidActionException : Exception
    {
        public InvalidActionException(string message) : base(message) { }
        public InvalidActionException(string message, Exception innerException) : base(message, innerException) { }
        public InvalidActionException() { }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Test.EventScheduler.Services.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string message) : base(message) { }
        public ItemNotFoundException(string message, Exception innerException) : base(message, innerException) { }
        public ItemNotFoundException() { }
    }
}

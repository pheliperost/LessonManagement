using System;
using System.Collections.Generic;

namespace LessonsManagement.Business.Models
{
    public class EventType : Entity
    {
        public String EventTypeName { get; set; }
        public String Notes { get; set; }
        public Decimal Price { get; set; }
        public Int32 DurationTimeInMinutes { get; set; }

        public IEnumerable<Lesson> Lessons { get; set; }
    }
}

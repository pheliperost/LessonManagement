using System;
using System.Collections.Generic;
using System.Text;

namespace LessonsManagement.Business.Models
{
    public class CalendarModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public string color { get; set; }
        public Guid lessonId { get; set; }
        public DateTime? start { get; set; }
        public DateTime? end { get; set; }
        public bool? allDay { get; set; }
    }
}

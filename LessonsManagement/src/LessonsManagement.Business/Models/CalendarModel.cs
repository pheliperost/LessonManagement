using System;
using System.Collections.Generic;
using System.Text;

namespace LessonsManagement.Business.Models
{
    public class CalendarModel
    {
        public string title { get; set; }
        public DateTime? start { get; set; }
        public DateTime? end { get; set; }
        public bool? allDay { get; set; }
    }
}

using System;

namespace LessonsManagement.Business.Models
{
    public class Lesson : Entity
    {
        public Guid? StudentId { get; set; }
        public Guid EventTypeId { get; set; }
        public DateTime ExecutionDate { get; set; }
        public String Notes { get; set; }

        //EF Relations
        public Student Student { get; set; }
        public EventType EventType { get; set; }

    }
}

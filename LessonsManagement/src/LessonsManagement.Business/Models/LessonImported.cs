using System;

namespace LessonsManagement.Business.Models
{
    public class LessonImported : Entity
    {
        public Guid FileImportedId { get; set; }

        public Guid? StudentId { get; set; }
        public Guid EventTypeId { get; set; }
        public DateTime ExecutionDate { get; set; }
        public Decimal Price { get; set; }

        //EF Relations
        public Student Student { get; set; }
        public EventType EventType { get; set; }
        public FileImported FileImported { get; set; }

    }
}

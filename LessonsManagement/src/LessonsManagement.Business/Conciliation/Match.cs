using System;

namespace LessonsManagement.Business.Conciliation
{
    public class Match
    {
        public Guid LessonId { get; set; }
        public Guid LessonImportedId { get; set; }
        public string StudenName { get; set; }
        public string StudenNameImported { get; set; }
        public string EventType { get; set; }
        public string EventTypeImported { get; set; }
        public DateTime ExecutionDate { get; set; }
        public DateTime ExecutionDateImported { get; set; }
        public decimal Price { get; set; }
        public decimal PriceImported { get; set; }
    }
}

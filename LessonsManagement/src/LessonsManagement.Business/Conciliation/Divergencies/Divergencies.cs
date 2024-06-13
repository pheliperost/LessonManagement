using LessonsManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonsManagement.Business.Conciliation.Divergencies
{
    public abstract class Divergencies
    {
        private string Message { get; set; }
        private string TypeError { get; set; }
        private string LessonId { get; set; }
        private string LessonImportedId { get; set; }
        private string LessonValue { get; set; }
        private string LessonImportedValue { get; set; }
        public Lesson _lesson { get; set; }
        public LessonImported _lessonImported { get; set; }

        public Divergencies(Lesson lesson, LessonImported lessonImported)
        {
            _lesson = lesson;
            _lessonImported = lessonImported;
        }
    }
}

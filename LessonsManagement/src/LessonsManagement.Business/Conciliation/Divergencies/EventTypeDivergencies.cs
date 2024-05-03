using LessonsManagement.Business.Conciliation.Divergencies.Interfaces;
using LessonsManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonsManagement.Business.Conciliation.Divergencies
{
    public class EventTypeDivergencies : Divergencies, ISetDivergencies
    {
        public EventTypeDivergencies(Lesson lesson, LessonImported lessonImported) : base(lesson, lessonImported) { }

        public DivergencyRow SetDivergencies()
        {
            var divergency = new DivergencyRow();

            if (_lesson.EventTypeId != _lessonImported.EventTypeId) {
                divergency.Message = "Execution Date: (" + _lesson.ExecutionDate.ToString() + ")" +
                                       ", Event Type: (" + _lessonImported.EventType.EventTypeName + ")" +
                                       ", Student: (" +
                                       (_lessonImported.Student != null ? _lessonImported.Student.StudentName + ")" : " - )");

                divergency.TypeError = "Event ID";
                divergency.LessonId = _lesson.Id.ToString();
                divergency.LessonImportedId = _lessonImported.Id.ToString();
                divergency.LessonValue = _lesson.EventType.EventTypeName.ToString();
                divergency.LessonImportedValue = _lessonImported.EventType.EventTypeName.ToString();
                
                return divergency;
            }

            return divergency;
        }

        
    }
}

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
            DivergencyRow divergency = new DivergencyRow();

            if (_lesson.EventTypeId != _lessonImported.EventTypeId) {
                divergency.Message = "Event Id different for lesson id " + " (lesson: " + _lesson.StudentId.ToString() 
                                    + " imported: " + _lessonImported.StudentId.ToString();

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

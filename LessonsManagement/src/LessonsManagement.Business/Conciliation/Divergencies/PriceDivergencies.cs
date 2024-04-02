using LessonsManagement.Business.Conciliation.Divergencies.Interfaces;
using LessonsManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonsManagement.Business.Conciliation.Divergencies
{
    public class PriceDivergencies : Divergencies, ISetDivergencies
    {
        public PriceDivergencies(Lesson lesson, LessonImported lessonImported) : base(lesson, lessonImported) { }

        public DivergencyRow SetDivergencies()
        {
            DivergencyRow divergency = new DivergencyRow();

            if (_lesson.EventType.Price != _lessonImported.Price) {
                divergency.Message = "Price is different for lesson id " + " (lesson: " + _lesson.StudentId.ToString() 
                                    + " imported: " + _lessonImported.StudentId.ToString();

                divergency.TypeError = "Price";
                divergency.LessonId = _lesson.Id.ToString();
                divergency.LessonImportedId = _lessonImported.Id.ToString();
                divergency.LessonValue = _lesson.EventType.Price.ToString();
                divergency.LessonImportedValue = _lessonImported.Price.ToString();
                
                return divergency;
            }

            return divergency;
        }

        
    }
}

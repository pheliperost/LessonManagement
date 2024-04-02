using LessonsManagement.Business.Conciliation.Divergencies.Interfaces;
using LessonsManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonsManagement.Business.Conciliation.Divergencies
{
    public class ExecutionDateDivergencies : Divergencies, ISetDivergencies
    {
        public ExecutionDateDivergencies(Lesson lesson, LessonImported lessonImported) : base(lesson, lessonImported) { }

        public DivergencyRow SetDivergencies()
        {
            DivergencyRow divergency = new DivergencyRow();

            if (_lesson.ExecutionDate != _lessonImported.ExecutionDate) {
                divergency.Message = "Execution Date different for lesson id " + " (lesson: " + _lesson.StudentId.ToString() 
                                    + " imported: " + _lessonImported.StudentId.ToString();

                divergency.TypeError = "Execution Date";
                divergency.LessonId = _lesson.Id.ToString();
                divergency.LessonImportedId = _lessonImported.Id.ToString();
                divergency.LessonValue = _lesson.ExecutionDate.ToString();
                divergency.LessonImportedValue = _lessonImported.ExecutionDate.ToString();
                
                return divergency;
            }

            return divergency;
        }

        
    }
}

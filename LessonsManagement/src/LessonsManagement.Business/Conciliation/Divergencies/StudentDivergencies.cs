using LessonsManagement.Business.Conciliation.Divergencies.Interfaces;
using LessonsManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonsManagement.Business.Conciliation.Divergencies
{
    public class StudentDivergencies : Divergencies, ISetDivergencies
    {
        public StudentDivergencies(Lesson lesson, LessonImported lessonImported) : base(lesson, lessonImported) { }

        public DivergencyRow SetDivergencies()
        {
            DivergencyRow divergency = new DivergencyRow();

            if (_lesson.StudentId != _lessonImported.StudentId) {
                divergency.Message = "Execution Date: (" + _lesson.ExecutionDate.ToString() + ")"+
                                     ", Event Type: (" + _lessonImported.EventType.EventTypeName + ")" +
                                     ", Student: (" + 
                                     (_lessonImported.Student != null ? _lessonImported.Student.StudentName+ ")" : " - )");

                divergency.TypeError = "Student ID";
                divergency.LessonId = _lesson.Id.ToString();
                divergency.LessonImportedId = _lessonImported.Id.ToString();
                divergency.LessonValue = _lesson.StudentId.ToString();
                divergency.LessonImportedValue = _lessonImported.StudentId.ToString();
                
                return divergency;
            }

            return divergency;
        }

        
    }
}

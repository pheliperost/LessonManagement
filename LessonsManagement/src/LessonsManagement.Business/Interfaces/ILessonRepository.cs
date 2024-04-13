using LessonsManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LessonsManagement.Business.Interfaces
{
    public interface ILessonRepository : IRepository<Lesson>
    {
        Task<Lesson> GetLesson(Guid Id);
        Task<IEnumerable<Lesson>> GetLessonsByExecutedDay(DateTime dateexecution);
        Task<IEnumerable<Lesson>> GetStudenAndEventTypetInLesson();
        Task<IEnumerable<Lesson>> GetLessonWithDetailsOrdernedByDate();
        Task<IEnumerable<Lesson>> GetLessonsByStudent(Guid lessonId);
        Task<IEnumerable<Lesson>> GetLessonsByPeriod(DateTime startDate, DateTime endDate);
        Task<EventType> ReturnEventTypeLesson();
        Task<IEnumerable<Lesson>> GetLessonFilter(string search);
        Task<IEnumerable<Lesson>> GetLessonToPopulateCalendar();

    }
}

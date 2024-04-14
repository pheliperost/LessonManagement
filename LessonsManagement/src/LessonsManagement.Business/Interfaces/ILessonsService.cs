using LessonsManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LessonsManagement.Business.Interfaces
{
    public interface ILessonsService : IDisposable
    {

        Task Add(Lesson lesson);
        Task Update(Lesson lesson);
        Task Delete(Guid id);
        Task<Lesson> ReturnEventTypeLesson();
        Task<IEnumerable<Lesson>> GetLessonsByPeriod(DateTime startDate, DateTime endDate);
        Task<List<CalendarModel>> GetLessonToPopulateCalendar();

    }
}

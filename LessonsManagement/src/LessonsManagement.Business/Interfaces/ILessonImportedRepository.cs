using LessonsManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LessonsManagement.Business.Interfaces
{
    public interface ILessonImportedRepository : IRepository<LessonImported>
    {
        Task<LessonImported> GetLessonImported(Guid Id);
        Task<LessonImported> GetLessonsImportedByStudent(Guid Id);
        Task<LessonImported> GetLesson(Guid Id);
        Task<IEnumerable<Lesson>> GetLessonsByExecutedDay(DateTime dateexecution);
        Task<IEnumerable<LessonImported>> GetStudenAndEventTypetInLesson();
        Task<IEnumerable<Lesson>> GetLessonsByStudent(Guid lessonId);
        Task<IEnumerable<LessonImported>> GetAllLessonsImportedByFile(Guid fileImportedID);
        Task<EventType> ReturnEventTypeLesson();
        Task DeleteAllLessonsImportedByFileId(Guid id);
        Task BulkInsert(List<LessonImported> listlessonImported);
    }
}

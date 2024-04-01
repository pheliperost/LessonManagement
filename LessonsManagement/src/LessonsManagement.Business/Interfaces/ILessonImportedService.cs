using LessonsManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LessonsManagement.Business.Interfaces
{
    public interface ILessonImportedService : IDisposable
    {
        Task Add(LessonImported lessonImported);
        Task AddBulk(List<LessonImported> lessonImported);
        Task DeleteAllLessonsImportedByFileId(Guid id);
        Task<IEnumerable<LessonImported>> GetAllLessonsImportedByFile(Guid id);
    }
}
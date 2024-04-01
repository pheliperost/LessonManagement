using EFCore.BulkExtensions;
using LessonsManagement.Business.Interfaces;
using LessonsManagement.Business.Models;
using LessonsManagement.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonsManagement.Data.Repository
{
    public class LessonImportedRepository : Repository<LessonImported>, ILessonImportedRepository
    {
        public LessonImportedRepository(DataDbContext dataDbContext) : base(dataDbContext) { }

        public async Task<IEnumerable<LessonImported>> GetAllLessonsImportedByFile(Guid fileImportedID)
        {
            return await _dataDbContext.LessonImported.Where(p => p.FileImportedId == fileImportedID)
                                                      .Include(f => f.Student)
                                                      .Include(f => f.EventType)
                                                      .AsNoTracking()
                                                      .ToListAsync();
        }

        public Task<LessonImported> GetLesson(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<LessonImported> GetLessonImported(Guid Id)
        {
            return await GetById(Id);
        }

        public Task<IEnumerable<Lesson>> GetLessonsByExecutedDay(DateTime dateexecution)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Lesson>> GetLessonsByStudent(Guid lessonId)
        {
            throw new NotImplementedException();
        }

        public async Task<LessonImported> GetLessonsImportedByStudent(Guid Id)
        {
            return await _dataDbContext.LessonImported.AsNoTracking().Include(f => f.Student)
                .FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<IEnumerable<LessonImported>> GetStudenAndEventTypetInLesson()
        {
            return await _dataDbContext.LessonImported.Include(f => f.Student).Include(f => f.EventType).Include(f => f.FileImported).AsNoTracking().ToListAsync();
        }

        public Task<EventType> ReturnEventTypeLesson()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAllLessonsImportedByFileId(Guid id)
        {
            var records = await _dataDbContext.LessonImported.Where(p => p.FileImportedId == id).AsNoTracking().ToListAsync();
            if (records.Count() > 0) _dataDbContext.LessonImported.RemoveRange(records);

            await SaveChanges();
        }

        public async Task BulkInsert(List<LessonImported> listlessonImported)
        {
             _dataDbContext.BulkInsert(listlessonImported);
        }
    }
}

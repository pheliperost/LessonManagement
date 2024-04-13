using LessonsManagement.Business.Interfaces;
using LessonsManagement.Business.Models;
using LessonsManagement.Business.Utils;
using LessonsManagement.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LessonsManagement.Data.Repository
{
    public class LessonRepository : Repository<Lesson>, ILessonRepository
    {
        public LessonRepository(DataDbContext dataDbContext) : base(dataDbContext) { }

        public async Task<Lesson> GetLesson(Guid Id)
        {
            return await _dataDbContext.Lesson.Where(p => p.Id == Id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Lesson>> GetLessonsByExecutedDay(DateTime dateexecution)
        {
            return await _dataDbContext.Lesson
                    .Where(p => p.ExecutionDate.Date.Equals(dateexecution))
                    .Include(f => f.EventType)
                    .AsNoTracking()
                    .ToListAsync();
        }


        public async Task<IEnumerable<Lesson>> GetStudenAndEventTypetInLesson()
        {
            return await _dataDbContext.Lesson
                .Include(f => f.Student)
                .Include(f => f.EventType)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Lesson>> GetLessonFilter(string search)
        {
             var resultSet = await _dataDbContext.Lesson
                .Include(f => f.Student)
                .Include(f => f.EventType)
                .AsNoTracking()
                .ToListAsync();

            var eventTypeRegisters = resultSet
                    .Where(p => p.EventType.EventTypeName.ToLower().Contains(search.ToLower()));
            
            var studenNameRegisters = resultSet
                                        .Where(f => f.Student != null)
                                        .Where(p => p.Student.StudentName.ToLower()
                                        .Contains(search.ToLower()));

            DateTime dateSearch;
            DateTime.TryParse(search, out dateSearch);

            var executionDateRegisters = resultSet.Where(p => p.ExecutionDate.Date.Equals(dateSearch.Date));

            List<Lesson> listResult = eventTypeRegisters.ToList();

            listResult.AddRange(studenNameRegisters.ToList());
            listResult.AddRange(executionDateRegisters);



            return listResult.Distinct().OrderByDescending(p =>p.ExecutionDate);
        }

        public async Task<IEnumerable<Lesson>> GetLessonWithDetailsOrdernedByDate()
        {
            return await _dataDbContext.Lesson.Include(f => f.Student)
                                              .OrderBy(f => f.ExecutionDate)
                                              .Include(f => f.EventType)
                                              .AsNoTracking()
                                              .ToListAsync();
        }

        public async Task<IEnumerable<Lesson>> GetLessonToPopulateCalendar()
        {
            return await _dataDbContext.Lesson.ToListAsync();
        }

        public async Task<IEnumerable<Lesson>> GetLessonsByStudent(Guid lessonId)
        {
            return await Search(p => p.Id == lessonId);
        }

        public async Task<IEnumerable<Lesson>> GetLessonsByPeriod(DateTime startDate, DateTime endDate)
        {
            try
            {
                return await _dataDbContext.Lesson.Where(f => f.ExecutionDate >= startDate
                                                              && f.ExecutionDate <= endDate)
                                                           .Include(f => f.Student)
                                                           .Include(f => f.EventType)
                                                           .AsNoTracking()
                                                           .ToListAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<EventType> ReturnEventTypeLesson()
        {
            return await _dataDbContext.EventType.Where(p => p.EventTypeName.Trim() == "Lesson").FirstOrDefaultAsync();
        }

        
    }
}

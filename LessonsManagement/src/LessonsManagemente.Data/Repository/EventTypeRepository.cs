using LessonsManagement.Business.Interfaces;
using LessonsManagement.Business.Models;
using LessonsManagement.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LessonsManagement.Data.Repository
{
    public class EventTypeRepository : Repository<EventType>, IEventTypeRepository
    {
        public EventTypeRepository(DataDbContext dataDbContext) : base(dataDbContext) { }

        public async Task<EventType> GetEventType(Guid Id)
        {
            return await _dataDbContext.EventType.AsNoTracking()
                 .FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<EventType> GetLessonsByEventType(Guid Id)
        {
            return await _dataDbContext.EventType.AsNoTracking().Include(f => f.Lessons)
                 .FirstOrDefaultAsync(p => p.Id == Id);
        }
    }
}

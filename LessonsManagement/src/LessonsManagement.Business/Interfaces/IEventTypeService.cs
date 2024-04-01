using LessonsManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LessonsManagement.Business.Interfaces
{
    public interface IEventTypeService : IDisposable
    {
        Task Add(EventType lesson);
        Task Update(EventType lesson);
        Task Delete(Guid id);
        Task<IEnumerable<EventType>> GetEventTypeByName(string name);
        //Task GetLessonsByEventType(Guid id);
    }
}

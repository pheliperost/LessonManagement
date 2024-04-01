using LessonsManagement.Business.Models;
using System;
using System.Threading.Tasks;

namespace LessonsManagement.Business.Interfaces
{
    public interface IEventTypeRepository : IRepository<EventType>
    {
        Task<EventType> GetEventType(Guid Id);
        Task<EventType> GetLessonsByEventType(Guid Id);
    }
}

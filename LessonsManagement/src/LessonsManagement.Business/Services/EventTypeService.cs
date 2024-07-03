using LessonsManagement.Business.Interfaces;
using LessonsManagement.Business.Models;
using LessonsManagement.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonsManagement.Business.Services
{
    public class EventTypeService : BaseService, IEventTypeService
    {
        private readonly IEventTypeRepository _eventTypeRepository;

        public EventTypeService(IEventTypeRepository eventTypeRepository,
                                INotifyer notifyer) : base(notifyer)
        {
            _eventTypeRepository = eventTypeRepository;
        }

        public async Task Add(EventType eventType)
        {
            if (!ExecuteValidation(new EventTypeValidation(), eventType)) return;

            await _eventTypeRepository.Add(eventType);

        }

        public async Task Delete(Guid id)
        {
            if (_eventTypeRepository.GetLessonsByEventType(id).Result?.Lessons?.Any() == true)
            {
                Notify("Exclusion not allowed! There is lessons assigned to this student.");

                return;
            }

            await _eventTypeRepository.Remove(id);
        }

        public async Task Update(EventType eventType)
        {
            if (!ExecuteValidation(new EventTypeValidation(), eventType)) return;

            await _eventTypeRepository.Update(eventType);
        }

        public async Task<IEnumerable<EventType>> GetEventTypeByName(string name)
        {
            return await _eventTypeRepository.Search(p => p.EventTypeName == name);
        }

        public void Dispose()
        {
            _eventTypeRepository?.Dispose();
        }
    }
}

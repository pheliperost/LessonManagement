using LessonsManagement.Business.Interfaces;
using LessonsManagement.Business.Models;
using LessonsManagement.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonsManagement.Business.Services
{
    public class LessonsService : BaseService, ILessonsService
    {
        ILessonRepository _lessonRepository;
        IEventTypeRepository _eventTypeRepository;

        public LessonsService(ILessonRepository lessonRepository,
                              IEventTypeRepository eventTypeRepository,
        INotifyer notifyer) : base(notifyer)
        {
            _lessonRepository = lessonRepository;
            _eventTypeRepository = eventTypeRepository;
        }

        public async Task Add(Lesson lesson)
        {
            if(!await CheckValidPeriodLesson(lesson)) return;
            if (!ExecuteValidation(new LessonsValidation(), lesson)) return;

            await _lessonRepository.Add(lesson);
        }

        public async Task Delete(Guid id)
        {
            await _lessonRepository.Remove(id);
        }

        public async Task Update(Lesson lesson)
        {
            if (!ExecuteValidation(new LessonsValidation(), lesson)) return;

            lesson = ClearStudentWhenNotLessonId(lesson);

            await _lessonRepository.Update(lesson);
        }

        public async Task<EventType> ReturnEventTypeLesson()
        {
            return await _lessonRepository.ReturnEventTypeLesson();
        }

        private Lesson ClearStudentWhenNotLessonId(Lesson lesson)
        {
            if (lesson.EventTypeId != _lessonRepository.ReturnEventTypeLesson().Result.Id)
            {
                lesson.StudentId = null;
            }

            return lesson;
        }

        Task<Lesson> ILessonsService.ReturnEventTypeLesson()
        {
            throw new NotImplementedException();
        }

        private async Task<bool> CheckValidPeriodLesson(Lesson lesson)
        {
            var timeDurationInMinutes = await _eventTypeRepository.GetEventType(lesson.EventTypeId);

            var dateStart = lesson.ExecutionDate;
            var dateEnd = lesson.ExecutionDate.AddMinutes(timeDurationInMinutes.DurationTimeInMinutes);
           

            var AllLessonsPerDay = await _lessonRepository.GetLessonsByExecutedDay(lesson.ExecutionDate.Date);

            var StartBeforeLessonAndFinishBeforeEnd = AllLessonsPerDay.Where(p => dateStart <= p.ExecutionDate
                                                            && dateEnd >= p.ExecutionDate.AddMinutes(p.EventType.DurationTimeInMinutes));
            
            var MiddleLessonAndEndAfterEnd = AllLessonsPerDay.Where(p =>dateStart >= p.ExecutionDate
                                                            && dateEnd  >= p.ExecutionDate.AddMinutes(p.EventType.DurationTimeInMinutes));
            
            
            if(StartBeforeLessonAndFinishBeforeEnd.Count() > 0 || MiddleLessonAndEndAfterEnd.Count() > 0)
            return false;

            return true;
        }

        public async Task<IEnumerable<Lesson>> GetLessonsByPeriod(DateTime startDate, DateTime endDate)
        {
            return await _lessonRepository.GetLessonsByPeriod(startDate, endDate);
        }

        public void Dispose()
        {
            _lessonRepository?.Dispose();
        }

    }
}

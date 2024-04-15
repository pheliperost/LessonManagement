using LessonsManagement.Business.Interfaces;
using LessonsManagement.Business.Models;
using LessonsManagement.Business.Models.Validations;
using LessonsManagement.Business.Utils;
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
            if(!await ISValidPeriodLesson(lesson)) return;
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

        private async Task<bool> ISValidPeriodLesson(Lesson lesson)
        {
            var timeDurationInMinutes = await _eventTypeRepository.GetEventType(lesson.EventTypeId);

            var dateStart = lesson.ExecutionDate;
            var dateEnd = lesson.ExecutionDate.AddMinutes(timeDurationInMinutes.DurationTimeInMinutes);
           

            var AllLessonsPerDay = await _lessonRepository.GetLessonsByExecutedDay(lesson.ExecutionDate.Date);

            foreach (var item in AllLessonsPerDay)
            {
                var result = DateOperations.CheckIfDatesOverlaps(dateStart,
                                                    dateEnd,
                                                    item.ExecutionDate,
                                                    item.ExecutionDate.AddMinutes(item.EventType.DurationTimeInMinutes));

                if (result)
                {
                    Notify("Invalid date execution, There is another lesson registered with this data range.");
                    return false;
                }
            }

            return true;
        }

        public async Task<IEnumerable<Lesson>> GetLessonsByPeriod(DateTime startDate, DateTime endDate)
        {
            return await _lessonRepository.GetLessonsByPeriod(startDate, endDate);
        }

        public async Task<List<CalendarModel>> GetLessonToPopulateCalendar()
        {
            var itensevt = await _lessonRepository.GetLessonWithDetailsOrdernedByDate();

             List<CalendarModel> events = new List<CalendarModel>();

            foreach (var item in itensevt)
            {
                CalendarModel itemCalendar = new CalendarModel();

                itemCalendar.title = item.Student!= null ? item.Student.StudentName :
                                                        item.EventType.EventTypeName;

                itemCalendar.description = item.ExecutionDate.ToString();
                itemCalendar.start = item.ExecutionDate;
                itemCalendar.end = ReturnEndDateTimeForLesson(item);
                itemCalendar.allDay = false;
                itemCalendar.color = setEventColor(item);

                events.Add(itemCalendar);
            }

            return events;
        }

        private string setEventColor(Lesson lesson)
        {
            if (lesson.Student != null)
                return "red";

            if (lesson.EventType.EventTypeName.ToLower() == "rehearsal")
                return "blue";

                return "orange";
        }

        private DateTime ReturnEndDateTimeForLesson(Lesson lesson)
        {
            return lesson.ExecutionDate.AddMinutes(lesson.EventType.DurationTimeInMinutes);
        }

        public void Dispose()
        {
            _lessonRepository?.Dispose();
        }

    }
}

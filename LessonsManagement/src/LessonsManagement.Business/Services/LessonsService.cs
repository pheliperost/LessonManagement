using LessonsManagement.Business.Interfaces;
using LessonsManagement.Business.Models;
using LessonsManagement.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LessonsManagement.Business.Services
{
    public class LessonsService : BaseService, ILessonsService
    {
        ILessonRepository _lessonRepository;

        public LessonsService(ILessonRepository lessonRepository,
                               INotifyer notifyer) : base(notifyer)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task Add(Lesson lesson)
        {
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

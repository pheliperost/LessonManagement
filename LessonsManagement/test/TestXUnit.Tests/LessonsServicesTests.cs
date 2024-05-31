using LessonsManagement.Business.Interfaces;
using LessonsManagement.Business.Models;
using LessonsManagement.Business.Notifications;
using LessonsManagement.Business.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestXUnitBusiness.Tests.Fixtures;
using Xunit;

namespace TestXUnitBusiness.Tests
{
    [Collection(nameof(LessonsCollection))]
    public class LessonsServicesTests
    {
        readonly LessonsFixtures _lessonsFixtures;
        readonly LessonsService _lessonsService;

        public LessonsServicesTests(LessonsFixtures lessonsFixtures)
        {
            _lessonsFixtures = lessonsFixtures;
            _lessonsService = _lessonsFixtures.GetService();
        }

        [Fact(DisplayName = "Adding new Valid Lesson Should Return Success.")]
        [Trait("Category", "Lessons Service")]
        public async Task  LessonsServices_AddNewValidLesson_ShouldReturnSuccess()
        {
            // Arrange
            var lesson = _lessonsFixtures.GenerateValidLesson();
            _lessonsFixtures.Mocker.GetMock<IEventTypeRepository>().Setup(c => c.GetEventType(lesson.EventTypeId))
                .Returns(Task.FromResult(lesson.EventType));

            IEnumerable<Lesson> lstLessonEmpty = Enumerable.Empty<Lesson>(); ;

            _lessonsFixtures.Mocker.GetMock<ILessonRepository>().Setup(c => c.GetLessonsByExecutedDay(lesson.ExecutionDate.Date))
                .Returns(Task.FromResult(lstLessonEmpty));

            // Act
            await _lessonsService.Add(lesson);

            // Assert
            _lessonsFixtures.Mocker.GetMock<ILessonRepository>().Verify(r => r.Add(lesson), Times.Once);
            _lessonsFixtures.Mocker.GetMock<INotifyer>().Verify(m => m.Handle(It.IsAny<Notification>()), Times.Never);
        }

        [Fact(DisplayName = "Adding new Invalid Lesson Should Return Error.")]
        [Trait("Category", "Lessons Service")]
        public async Task LessonsServices_AddNewInvalidLesson_ShouldReturnError()
        {
            // Arrange
            var lesson = _lessonsFixtures.GenerateInvalidLesson();
            _lessonsFixtures.Mocker.GetMock<IEventTypeRepository>().Setup(c => c.GetEventType(lesson.EventTypeId))
                .Returns(Task.FromResult(lesson.EventType));

            IEnumerable<Lesson> lstLessonEmpty = Enumerable.Empty<Lesson>(); ;

            _lessonsFixtures.Mocker.GetMock<ILessonRepository>().Setup(c => c.GetLessonsByExecutedDay(lesson.ExecutionDate.Date))
                .Returns(Task.FromResult(lstLessonEmpty));

            // Act
            await _lessonsService.Add(lesson);

            // Assert
            _lessonsFixtures.Mocker.GetMock<ILessonRepository>().Verify(r => r.Add(lesson), Times.Never);
            _lessonsFixtures.Mocker.GetMock<INotifyer>().Verify(m => m.Handle(It.IsAny<Notification>()), Times.Exactly(2));
        }

        [Fact(DisplayName = "Updating Valid Lesson Should Return Success.")]
        [Trait("Category", "Lessons Service")]
        public async Task LessonsServices_UpdateValidLesson_ShouldReturnSuccess()
        {
            // Arrange
            var lesson = _lessonsFixtures.GenerateValidLesson();

            _lessonsFixtures.Mocker.GetMock<ILessonRepository>().Setup(c => c.ReturnEventTypeLesson())
                .Returns(Task.FromResult(lesson.EventType));

            lesson.ExecutionDate = lesson.ExecutionDate.AddDays(1) ;
            lesson.Notes = "updated";

            // Act
            await _lessonsService.Update(lesson);

            // Assert
            _lessonsFixtures.Mocker.GetMock<ILessonRepository>().Verify(r => r.Update(lesson), Times.Once);
            _lessonsFixtures.Mocker.GetMock<INotifyer>().Verify(m => m.Handle(It.IsAny<Notification>()), Times.Never);

        }

        [Fact(DisplayName = "Updating Invalid Lesson Should Return Error.")]
        [Trait("Category", "Lessons Service")]
        public async Task LessonsServices_UpdateInvalidLesson_ShouldReturnError()
        {
            // Arrange
            var lesson = _lessonsFixtures.GenerateInvalidLesson();

            _lessonsFixtures.Mocker.GetMock<ILessonRepository>().Setup(c => c.ReturnEventTypeLesson())
                .Returns(Task.FromResult(lesson.EventType));

            lesson.ExecutionDate = DateTime.MinValue;
            lesson.Notes = null;

            // Act
            await _lessonsService.Update(lesson);

            // Assert
            _lessonsFixtures.Mocker.GetMock<ILessonRepository>().Verify(r => r.Update(lesson), Times.Never);
            _lessonsFixtures.Mocker.GetMock<INotifyer>().Verify(m => m.Handle(It.IsAny<Notification>()), Times.Exactly(2));

        }

        [Fact(DisplayName = "Delete Valid Lesson Should Return Success.")]
        [Trait("Category", "Lessons Service")]
        public async Task LessonsServices_DeleteValidLesson_ShouldReturnSuccess()
        {
            // Arrange
            var lesson = _lessonsFixtures.GenerateValidLesson();

            _lessonsFixtures.Mocker.GetMock<IEventTypeRepository>().Setup(c => c.GetEventType(lesson.EventTypeId))
                .Returns(Task.FromResult(lesson.EventType));

            IEnumerable<Lesson> lstLessonEmpty = Enumerable.Empty<Lesson>(); ;

            _lessonsFixtures.Mocker.GetMock<ILessonRepository>().Setup(c => c.GetLessonsByExecutedDay(lesson.ExecutionDate.Date))
                .Returns(Task.FromResult(lstLessonEmpty));

            _lessonsFixtures.Mocker.GetMock<ILessonRepository>().Setup(c => c.GetById(lesson.Id))
                .Returns(Task.FromResult(lesson));

            await _lessonsService.Add(lesson);

            _lessonsFixtures.Mocker.GetMock<ILessonRepository>().Verify(r => r.Add(lesson), Times.Once);
            _lessonsFixtures.Mocker.GetMock<INotifyer>().Verify(m => m.Handle(It.IsAny<Notification>()), Times.Never);
            
            // Act
            await _lessonsService.Delete(lesson.Id);

            // Assert
            _lessonsFixtures.Mocker.GetMock<ILessonRepository>().Verify(r => r.Remove(lesson.Id), Times.Once);
            _lessonsFixtures.Mocker.GetMock<INotifyer>().Verify(m => m.Handle(It.IsAny<Notification>()), Times.Never);

        }

        [Fact(DisplayName = "Delete Invalid Lesson Should Return Error.")]
        [Trait("Category", "Lessons Service")]
        public async Task LessonsServices_DeleteInvalidLesson_ShouldReturnError()
        {
            // Arrange
            var lesson = _lessonsFixtures.GenerateValidLesson();

            // Act
            await _lessonsService.Delete(lesson.Id);

            // Assert
            _lessonsFixtures.Mocker.GetMock<ILessonRepository>().Verify(r => r.Remove(lesson.Id), Times.Never);
            _lessonsFixtures.Mocker.GetMock<INotifyer>().Verify(m => m.Handle(It.IsAny<Notification>()), Times.AtLeastOnce);

        }
    }
}
